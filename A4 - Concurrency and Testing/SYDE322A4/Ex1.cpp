#include "stdafx.h"
#include <thread>
#include <atomic>
#include <mutex>
#include <iostream>

#define NUM_THREADS 300
using namespace std;

class Ex1 {

	bool numberIsPrime;
	atomic<bool> threadsReady = false;
	mutex mutexLock;

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

public:
	void runExercise() {
		int number = 654323;

		std::thread threads[NUM_THREADS];

		//p = &Ex1::isPrime;
		//CA cA;
		for (int i = 0; i < NUM_THREADS; i++)
			threads[i] = std::thread(isPrime, i, number);

		threadsReady = true;

		// Synchronize threads
		for (auto &thread : threads)
			thread.join();
	}
};