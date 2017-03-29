// SYDE322A4.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <iostream>
#include <thread>
#include <atomic>
#include <mutex>
#include "Semaphore.h"
using namespace std;

bool numberIsPrime(true);
atomic<bool> threadsReady(false);
mutex mutexLock;

////////////////
// EXERCISE 1 //
////////////////
#define NUM_THREADS 300

// checks if the given number is a prime number
void isPrime(int threadId, int potentialPrime)
{
	// threadID is the ID of the current thread
	// potentialPrime is the number that needs to be checked if it is a prime
	while (!threadsReady) {
		std::this_thread::yield();
	}

	mutexLock.lock();
	numberIsPrime = true;
	mutexLock.unlock();

	for (int i = 2; i < potentialPrime; i++)
	{
		if (potentialPrime % i == 0)
		{
			mutexLock.lock();
			numberIsPrime = false;
			mutexLock.unlock();
		}
	}

	mutexLock.lock();
	if (numberIsPrime)
		cout << "Thread #" << threadId << " finished first! " << potentialPrime << " is a prime." << endl;

}

void runExercise1()
{
	const int NUMBER = 654323;

	std::thread threads[NUM_THREADS];

	for (int i = 0; i < NUM_THREADS; i++)
		threads[i] = std::thread(isPrime, i, NUMBER);

	threadsReady = true;

	// Synchronize threads
	for (auto &thread : threads)
		thread.join();
}

////////////////
// EXERCISE 2 //
////////////////

// checks if the given number is divisible by any of the numbers from a range
void isDivisibleBy(int threadID, int targetNumber, int start, int end)
{
	// threadID is the ID of the current thread
	// targetNumber is the number that needs to be checked for divisibility
	// start is the smallest number in the given range
	// end is the largest number in the given range

	while (!threadsReady) {
		std::this_thread::yield();
	}

	
	mutexLock.lock();
	cout << "Thread " << threadID << " is finding divisors within range " << start << " to " << end << endl;
	mutexLock.unlock();

	for (int i = start; i < end; i++){
		if (targetNumber % i == 0) {
			mutexLock.lock();
			cout << targetNumber << " is divisible by " << i << endl;
			numberIsPrime = false;
			mutexLock.unlock();
		}
	}

	mutexLock.lock();
	cout << "Thread #" << threadID << " is done." << endl;
	mutexLock.unlock();

}

void runExercise2()
{
	const int NUMBER = 654324;
	const int NUM_THREADS_EX2 = 10;

	std::thread threads[NUM_THREADS_EX2];

	int interval = NUMBER / NUM_THREADS_EX2;

	cout << "For " << NUM_THREADS_EX2 << " threads, dividing number " << NUMBER << " into an interval of " << interval << endl;

	int start = 2;
	int end = start + interval;
	for (int i = 0; i < NUM_THREADS_EX2; i++)
	{ 
		threads[i] = std::thread(isDivisibleBy, i, NUMBER, start, end);
		start = end + 1;
		end += interval;
	}
		
	threadsReady = true;

	// Synchronize threads
	for (auto &thread : threads)
		thread.join();

	if (!numberIsPrime)
		cout << NUMBER << " is not a prime." << endl;
	else
		cout << NUMBER << " is a prime." << endl;

}

////////////////
// EXERCISE 3 //
////////////////
unsigned int readersCount = 0;
unsigned int counter = 0;

void read(Semaphore* writer, Semaphore* reader)
{
	do {
		reader->wait();

		readersCount++;
		if (readersCount == 1)
			writer->wait();

		reader->signal();
		// Read data
		cout << "Reading data, counter = " << counter << endl;
		reader->wait();

		readersCount--;
		if (readersCount == 0)
			writer->signal();

		reader->signal();
	} while (true);
}

void write(Semaphore* writer, Semaphore* reader)
{
	do {
		writer->wait();
		// Write data
		counter++;
		cout << "Writing data, counter = " << counter << endl;
		writer->signal();
	} while (true);
}

void runExercise3()
{
	cout << "Implementing a semaphore to solve a readers-writer synchronization problems" << endl;

	Semaphore writer(1);
	Semaphore reader(1);

	thread readerThread = thread(read, &writer, &reader);
	thread writerThread = thread(write, &writer, &reader);

	readerThread.join();
	writerThread.join();
}

int main()
{
	// To be run one at a time so comment exercises as so.
	runExercise1();
	runExercise2();
	runExercise3();

	system("pause");
	return 0;
}