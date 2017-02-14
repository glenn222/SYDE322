"use strict";
var botbuilder_azure = require("botbuilder-azure");

var useEmulator = (process.env.NODE_ENV == 'development');

const BEST_BUY_BASE_API_URL = "https://api.bestbuy.com/v1/";
const BEST_BUY_PRODUCTS_ENDPOINT = "products";
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

let categoriesArr = [];

function isEmpty(val)
{
	return (val === undefined || val == null || val.length <= 0) ? true : false;
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

function filterResultsByPrice(productsData, price)
{
	let products = [];

	for ( let i = 0; i < productsData.length; i++ )
		if (productsData[i].salePrice <= price)
			products.push(productsData[i]);
	
	return products;
}

function showProducts(session, products, limit)
{
	let productLimit = ((limit > products.length && limit < 0) || (isEmpty(limit))) ? products.length : limit;
	
	session.send("Here are %s products you may be interested in: ", productLimit);
	let productsArray = [];

	for ( let index = 0; index < productLimit; index++ ){
		productsArray.push( "Product " + (index+1) + ":", "Name - " + products[index].name, "Price - " + products[index].salePrice);
	}

	let productsString = productsArray.join("\n");
	session.send(productsString);
}

function showProduct(session, products)
{
	let product = products[0];
	let productKeys = Object.keys(product);
	let productObj = {};
	
	for ( let i = 0; i < productKeys.length; ++i ) {
		if (!isEmpty(product[productKeys[i]]))
			productObj[productKeys[i]] = product[productKeys[i]];
	}
	
	return productObj;
}

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

			bestbuy.products('(search=' + searchTerm + ')', {show: 'upc,salePrice,name', pageSize: 100}, function(err, data)
			{
				if (err)
					throw err;
				else if (data.total === 0)
					session.endDialog("Sorry, I couldn't find any products under the category " + results.response);
				else{
					session.dialogData.ProductsData = data.products;
					session.send('I found %d products. An example product I found was "%s" is $%d', data.total, data.products[0].name, data.products[0].salePrice);
					
					if (data.total > 0){
						builder.Prompts.text(session, "How many products would you like to show out of " + data.total + "? (Limit 100)" );
					}
					else
						session.endDialog("Sorry, I couldn't find any products under the %s category", session.dialogData.CategoryName);
				}
			});
			
		}
	},
	(session, results, next) => {
		if ( results.response > 0 && results.response <= session.dialogData.ProductsData.length ){
			session.dialogData.ProductLimit = results.response;
		
			showProducts(session, session.dialogData.ProductsData, results.response );

			builder.Prompts.number(session, "What is the maximum budget you're willing to spend on a " + session.dialogData.CategoryName + "-based product?");
		}else{
			session.endDialog("Sorry that's not a valid number! Please try again!");
			session.reset();
		}
	},
	(session, results) =>
	{
		if ( results.response > 0 && results.response <= Number.POSITIVE_INFINITY )
			session.dialogData.MaxBudget = results.response;
		else{
			session.endDialog("Sorry that's not a valid number! Please try again!");
			session.reset();
		}
		
		session.send("Ok, I'll see if there's any products that are under $%d.", results.response);
		
		session.dialogData.FilteredResults = filterResultsByPrice(session.dialogData.ProductsData, results.response);
		
		if (session.dialogData.FilteredResults.length === 0)
			session.endDialog("I couldn't find any results matching your selection, sorry.");
		
		showProducts(session, session.dialogData.FilteredResults);
		
		session.send("Is there a specific product from the list that interests you? I'll see if I can gather more information on it.")
		builder.Prompts.text(session, "Type in the product number (1-" + session.dialogData.FilteredResults.length + ")");
		
	},
	(session, results, next) =>
	{
		let productIndex = Number(results.response) - 1;
		if (productIndex > session.dialogData.FilteredResults.length || productIndex < 0){
			session.endDialog("That's not a possible item, please try again thanks");
			session.reset();
		}else{
			let productUPC = session.dialogData.FilteredResults[productIndex].upc;
			
			session.dialogData.ProductUPC = productUPC;
			session.send("Thanks, you chose product %s", (productIndex+1));

			bestbuy.products('upc=' + productUPC, (err, data) => {
				session.dialogData.ProductData = data.products;
				next();
			});
		}
	},
	(session, results) => {
		let filteredData = showProduct(session, session.dialogData.ProductData);
		
		session.send("Here's some more useful data about %s\n", filteredData.name);
		session.send(JSON.stringify(filteredData, null, 4));
		
		session.send("Hope I helped you out! Happy to be at your service!");
		session.reset();
	}
]);

intents.onDefault((session) => {
	session.send('Hey there! I am a Best Buy API Bot. Say hello to begin!');
});