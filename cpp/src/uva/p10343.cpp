// Problem ID:	10343
// Name:		Base64 Decoding
// URI:			https://uva.onlinejudge.org/external/103/10343.pdf
#define DONLINE_JUDGE

//#ifdef _MSC_VER
//#define _CRT_SECURE_NO_WARNINGS
//#endif


#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include <numeric>
#include <string>
#include <queue>
#include <iterator>
#include <sstream>//
#include <tuple>
#include <iomanip>
#include <map>

#ifndef DONLINE_JUDGE
#include <fstream>
	//std::ifstream cin{ ".\\uva11459\\in.txt" };
	//std::ifstream cin{ ".\\uva11459\\in1.txt" };
	//std::ifstream cin{ ".\\uva11459\\in2.txt" };
	//std::ifstream cin{ ".\\uva11459\\in3.txt" };
	std::ifstream cin{ ".\\uva11459\\in4.txt" };
#else
#include <iostream>
using std::cout;
using std::cin;
#endif

#ifndef _BASE64_ENCODER_
#define _BASE64_ENCODER_

class Base64Encoder {
public:
	static std::vector<uint8_t> fromBase64String(std::string s) {
		std::vector<uint8_t> res;
		return res;
	}

	static std::string getString(std::vector<uint8_t> bytes) {
		std::string str;
		for (uint32_t n : bytes) {			
			str += static_cast<char>(n);
		}
		return str;
	}
};
#endif // _BASE64_ENCODER_


#if !defined RUN_UNIT_TESTS
int main(int argc, char* argv[]) {
	if (!cin) {
		std::cerr << "Failed to open file" << std::endl;
	}
	std::string str;
	while (std::getline(cin, str)) {
		if (str == "#") cout << str;
		else if (str == "##") {
			cout << "#"; break;
		}
		else {
			cout << Base64Encoder::getString(Base64Encoder::fromBase64String(str));
		}
	}
	std::cout << std::endl;
	getchar();
	return 0;
}
#endif

