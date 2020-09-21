
// Problem ID:	11059
// Name:		Maximum Product
// URI:			https://uva.onlinejudge.org/external/110/11059.pdf
#define DONLINE_JUDGE

#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include <numeric>
#include <string>
#include <queue>
#include <iterator>
#include <sstream>
#include <tuple>

#ifndef DONLINE_JUDGE
#include <fstream>
 //std::ifstream cin{ "in.txt" };
 std::ofstream cout("out.txt");
 std::ifstream cin{ "in.txt" };
#else
#include <iostream>
using std::cin;
using std::cout;
#endif

typedef std::vector<int> vi;

class MaxProduct {
public:
	static long long calculate(const vi& v) {
		long long max = 0;
		for (int i = 0; i < v.size(); i++) {
			long long t = v[i];
			max = std::max(max, t);
			for (int j = i + 1; j < v.size(); j++) {
				t *= v[j];
				if (t > max) {
					max = t;
				}
			}
		}
		return max;
	}
};

int main(int argc, char* argv[]) {
	if (!cin) {
		std::cerr << "Failed to open file" << std::endl;
	}
	int i = 1, n, x;
	while (cin >> n) {
		vi v;
		if (n > 0) {
			while (n-- > 0 && cin >> x) v.push_back(x);
			std::cout << "Case #" << i++ << ": The maximum product is " << MaxProduct::calculate(v) << "." << std::endl;
		}
		std::cout << std::endl;
	}
	return 0;
}





