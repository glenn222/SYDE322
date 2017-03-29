#pragma once

class Semaphore {
private:
	unsigned int S;
public:
	Semaphore(unsigned int initialValue) {
		S = initialValue;
	}

	void wait() {
		// decrement the semaphore
		while (S <= 0) {};

		S--;

		return;
	}
	void signal() {
		// increment the semaphore
		S++;

		return;
	}
};