#include <iostream>
#include <complex>
#include <vector>

using namespace std;

void print(std::initializer_list<int> vals) {
	for (auto val : vals) {
		std::cout << val << "\n";
	}
}

class Foo {
public:
	Foo(int, int) {
	}
	Foo(std::initializer_list<int> vals) {
		
	}
};

int main(int argc, char* argv[]) {

	// Before initialization could happen with parentheses, braces, and/or assignment operators.
	// For this reason, C++11 introduced the concept of uniform initialization, which means that for
	// any initialization, you can use one common syntax.

	
	int values[] { 1, 2, 3 };
	std::vector<int> v { 2, 3, 5, 7, 11, 13, 17 };
	vector<std::string> cities {
		"Berlin", "New York", "London", "Braunschweig", "Cairo", "Cologne"
	};
	complex<double> c{4.0,3.0};

	// An initializer list forces so-called value initialization, which means that even local variables of
	// fundamental data types, which usually have an undefined initial value, are initialized by zero (or
	// nullptr, if it is a pointer):
		
	int i; // i has undefined value
	int j{}; // j is initialized by 0
	int* p; // p has undefined value
	int* q{}; // q is initialized by nullptr

	// Note, however, that narrowing initializations — those that reduce precision or where the supplied
	// value gets modified— are not possible with braces. For example:

	int x = 1000;
	char y = x;
	cout << "y=x; " << (int)y << endl;

	// Using Uniform Initialization to Prevent Narrowing Conversions.
	// Narrowing conversions occur
	// when data is transferred from one type to another wherein the destination type cannot
    // store all of the values represented by the source type
	
	int x1(5.3); // OK, but OUCH: x1 becomes 5
	int x2 = 5.3; // OK, but OUCH: x2 becomes 5
//	int x3{5.0}; // ERROR: narrowing
//	int x4 = {5.3}; // ERROR: narrowing
	char c1{7}; // OK: even though 7 is an int, this is not narrowing
//	char c2{99999}; // ERROR: narrowing (if 99999 doesn’t fit into a char)
	std::vector<int> v1 { 1, 2, 4, 5 }; // OK
//	std::vector<int> v2 { 1, 2.3, 4, 5.6 }; // ERROR: narrowing doubles to ints
	double bigNumber{ 1.0 };

	// static_cast to inform the compiler that the narrowing
    // conversions are intentional and to compile the code.
	float littleNumber{ static_cast<float>(bigNumber) };


	print({1, 2, 3, 4, 5});
}