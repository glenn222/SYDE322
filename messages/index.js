"use strict";
var botbuilder_azure = require("botbuilder-azure");

var useEmulator = (process.env.NODE_ENV == 'development');

const BEST_BUY_BASE_API_URL = "https://api.bestbuy.com/v1/";
const BEST_BUY_PRODUCTS_ENDPOINT = "products";
const BEST_BUY_RECOMMENDATIONS_ENDPOINT = "recommendations";
const BEST_BUY_OPEN_BOX_ENDPOINT = "courses";
const QUERY_BEST_BUY_API_KEY = '?apiKey=ddefqg2f9bnr9zgxc4dwdfbv';
const DATA_FORMAT_EXTENSION = '.json';

const API_KEY = 'ddefqg2f9bnr9zgxc4dwdfbv'

const bestbuy = require('bestbuy')(API_KEY);
require('console.table');

const categories = require('./BestBuyCategories.json');

const fs = require('fs');

// Provides access to Bot Builder
const builder = require('botbuilder');
// Use HTTP module
const http = require('http');
// Use HTTPS module
const https = require('https');
// Connect to bot services
const connector = useEmulator ? new builder.ChatConnector() : new botbuilder_azure.BotServiceConnector({
    appId: process.env['MicrosoftAppId'],
    appPassword: process.env['MicrosoftAppPassword'],
    stateEndpoint: process.env['BotStateEndpoint'],
    openIdMetadata: process.env['BotOpenIdMetadata']
});

// Use universal Bot
const bot = new builder.UniversalBot(connector);

let apiResponse;

if (useEmulator) {
    var restify = require('restify');
    var server = restify.createServer();
    server.listen(3978, function() {
        session.send('test bot endpont at http://localhost:3978/api/messages');
    });
    server.post('/api/messages', connector.listen());    
} else {
    module.exports = { default: connector.listen() }
}

function obtainResultsAsync(session, response)
{
	let jsonData = '';
		
	response.on('data', (item) => { // join individual data items
		jsonData += item;
	});
	
	response.on('end', () => { // parse JSON string
		apiResponse = JSON.parse(jsonData);
		session.send('Here are the results.');
		
		parseResults(session, apiResponse);
		
		session.reset();
	});
}

function parseResults(session, data)
{
	if (data.total === 0)
	  session.send('No categories found');
	else
	  session.send('Found %d categories. First category (%s): %s', data.total, data.categories[0].id, data.categories[0].name);
}

function traverseJson(session, jsonObj, func) {
    for (let i in jsonObj) {
        session.send(func.apply(this,[i, jsonObj[i]]));  
        if (jsonObj[i] !== null && typeof(jsonObj[i])=="object")
            traverseJson(session, jsonObj[i], func);
    }
}

function displayKVP( key, value )
{
	return key + " - " + value;
}

function populateResponses(dialogData)
{
	let responses = [];
	
	for ( let i in dialogData )
		responses.push(dialogData[i]);
	
	return responses;
}

function constructUrl(dialogData)
{
	responseData = populateResponses(dialogData);
	let Intent = responseData[0];
	responseData = responseData.splice(2);
	
	let pathName;
	let filter = '';
	
	pathName = responseData.join("/");
	
	pathName = pathName.concat(DATA_FORMAT_EXTENSION).concat(QUERY_BEST_BUY_API_KEY);
	
	let fullApiURL = BEST_BUY_BASE_API_URL.concat(pathName).toLowerCase();
	
	session.send(fullApiURL);
	traverseJson(responseData, displayKVP);
	
	return fullApiURL;
}

// Create IntentDialog instance
const intents = new builder.IntentDialog();
bot.dialog('/', intents);

intents.matches(/^Course/i, [ // perform text matching
	(session) => {
		session.dialogData.Intent = UW_COURSES_ENDPOINT_URL;
		builder.Prompts.text(session, 'Enter the course subject you are you interested in. (Ex. SYDE, NE, ECE, etc...)');
		
	},
	(session, results) => {
		session.dialogData.CourseSubject = results.response;
		builder.Prompts.text(session, 'Enter the course number you are you interested in for ' +  results.response + '. (Ex. 100, 322, 232)');
	},
	(session, results) => {
		session.dialogData.CourseNumber = results.response;
		
		let url = constructUrl(session.dialogData);
		
		// retrieve data from a given url
		https.get(url, (response) => {
			obtainResultsAsync(session, response);
		});
	}
]);

intents.matches(/^Category/i, [
	(session) => {
		builder.Prompts.text(session, 'Is there any specific category you would be interested in?');
	},
	(session, results) => {
		session.dialogData.CategoryName = results.response;
		
		session.send('Here are some upcoming events at the University of Waterloo.');
		
		let url = constructUrl(session.dialogData);
		
		// retrieve data from a given url
		https.get(url, (response) => {
			obtainResultsAsync(session, response);
		});
	}
]);

let tableArr = [];
let categoriesArr = [];

function showCategories(session, limit)
{
	if (categoriesArr.length === 0)
	{
		for ( let index = 0; index < categories.length; index++ )
		{
			categoriesArr.push(categories[index].name);

			if ( index == limit )
				break;
		}
	}
	
	let categoriesStr = categoriesArr.join("\n");
	
	session.send("Here are some categories: ");
	session.send(categoriesStr);
}

function showProducts(session, products, limit)
{
	limit = limit || products.total;

	session.send("Here are some products you may be interested in: ");
	let productsArray = [];
	
	for ( let index = 0; index < limit; index++ )
	{
		productsArray.push( "Product " + (index+1) + ":", products[index].name, products[index].salePrice, "\n");
	}
	
	let productsString = productsArray.join("\n");
	session.send(productsString);
}

function populateCategories(session)
{
	session.send("Finding categories...");

	for (let index = 0; index < categories.length; index += 2){		
		category = {
			Column_1: categories[index + 0].name,
			Column_2: categories[index + 1].name
		}
		tableArr.push(category);
		// Just show first 10 categories out of many
		if (index == 10)
			break;
	}
	console.table(tableArr);
}

function isValidCategory(session, category)
{
	for ( let c in categoriesArr ){
		if (categoriesArr[c].toLowerCase() === category.toLowerCase()){
			return true;
		}
	}
	
	return false;
}

function filterResultsByPrice(productsData, price)
{
	let products = [];

	for ( let i = 0; i < productsData.length; i++ )
		if (productsData.products[i].salePrice <= price)
			products.push(productsData.products[i]);
	
	return products;
}

bot.dialog('/recommend', [
	(session) => {
		console.table(tableArr);
		builder.Prompts.text("Choose a category from the list provided");
	}
]);

intents.matches(/^Hello/i, [
	(session) => { // match text expression
		builder.Prompts.text(session, "Please type a category that interests you from the list provided");
		
		showCategories(session, 200);
	},
	(session, results, next) => {
		if ( !isValidCategory(session, results.response) )
		{
			session.endDialog("Sorry! This isn't a valid category");
		}else{
			session.dialogData.CategoryName = results.response;
			
			let searchTerm = session.dialogData.CategoryName.split(" ").join("&search=");

			bestbuy.products('(search=' + searchTerm + ')', {show: 'salePrice,name', pageSize: 100}, function(err, data)
			{
				if (err){
					throw err;
				}else if (data.total === 0)
					session.endDialog("Sorry, I couldn't find any products under the category " + results.response);
				else{
					session.dialogData.ProductsData = data.products;
					session.send('I found %d products. An example product I found was "%s" is $%d', data.total, data.products[0].name, data.products[0].salePrice);
					showProducts(session, data.products, data.total);
					
					if (data.total > 0){
						builder.Prompts.number(session, "How many products would you like to show out of " + data.total + "? (Limit 100)" );
					}
					else
						session.endDialog("Sorry, I couldn't find any products under the %s category", session.dialogData.CategoryName);
				}
			});
			
			builder.Prompts.number(session, "What is the maximum budget you're willing to spend on a " + session.dialogData.CategoryName + "-based product?");
			//session.dialogData.ProductsData = getProducts(session, session.dialogData.CategoryName, 100);
		}
	},
	(session, results, next) => {
		session.dialogData.ProductLimit = results.response;
																
		showProducts(session, session.dialogData.ProductsData, session.dialogData.ProductLimit );

		builder.Prompts.number(session, "What is the maximum budget you're willing to spend on a " + session.dialogData.CategoryName + "-based product?");
		//session.dialogData.ProductsData = getProducts(session, session.dialogData.CategoryName, results.response);

	},
	(session, results) =>
	{
		if ( results.response > 0 && results.response <= Number.POSITIVE_INFINITY )
			session.dialogData.MaxBudget = results.response;

		session.send("Ok, I'll see if there's any products that are under $%d.", results.response);
		
		session.dialogData.FilteredResults = filterResultsByPrice(results.response);

		showProducts(session, session.dialogData.FilteredResults );
	}
]);

function getProducts(session, categoryName, pageSizeAmount)
{
	let searchTerm = categoryName.split(" ").join("&search=");

	bestbuy.products('(search=' + searchTerm + ')', {show: 'salePrice,name', pageSize: pageSizeAmount}, function(err, data)
	{
		if (err){
			throw err;
		}else if (data.total === 0)
			session.endDialog("Sorry, I couldn't find any products under the category " + results.response);
		else{
			session.dialogData.ProductsData = data;
			session.send('I found %d products. An example product I found was "%s" is $%d', data.total, data.products[0].name, data.products[0].salePrice);
			
			if (data.total > 0 && pageSizeAmount == 1)
				builder.Prompts.number(session, "How many products would you like to show out of " + data.total + "? (Limit 100)" );
			else if (data.total > 0 && pageSizeAmount != 1)		
				builder.Prompts.number(session, "What is the maximum budget you're willing to spend on a " + session.dialogData.CategoryName + "-based product?");
			else
				session.endDialog("Sorry, I couldn't find any products under the %s category", session.dialogData.CategoryName);
		}
	});
}

intents.onDefault((session) => {
	session.send('Hey there! I am a Best Buy API Bot. Say hello to begin!');
});