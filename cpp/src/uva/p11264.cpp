// Problem ID:	11264
// Name:		Coin Collector
// URI:			https://uva.onlinejudge.org/external/112/11264.pdf
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
  //std::ofstream cout("out.txt");
  std::ifstream cin{ ".\\uva11264\\in.txt" };
#else
#include <iostream>
using std::cin;
using std::cout;
#endif

typedef std::vector<int> vi;


class Calculator {
public:
	static int getMax(const vi& v) {
		int i = 0, sum = v[i++], max = 2;
		for (; i < v.size()-1; i++) {
			if ((v[i] + sum) < v[i+1]) {
				sum += v[i];
				max += 1;
			}
		}
		return max;
	}
};



int main(int argc, char* argv[]) {
	if (!cin) {
		std::cerr << "Failed to open file" << std::endl;
	}
	int n, i, x;
	cin >> n;
	while (n-- > 0) {
		vi v;
		if (cin >> i) {
			while (i-- > 0 && cin >> x) v.push_back(x);
			std::cout << Calculator::getMax(v);
		}
		std::cout << std::endl;
	}
	return 0;
}





