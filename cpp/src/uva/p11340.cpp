// Problem ID:	11340
// Name:		Newspaper
// URI:			https://uva.onlinejudge.org/external/113/11340.pdf
#define DONLINE_JUDGE

#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif


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
#include <iomanip>
#include <map>

#ifndef DONLINE_JUDGE
#include <fstream>
 //std::ifstream cin{ ".\\uva11340\\in.txt" };
#else
#include <iostream>
using std::cout;
#endif

using std::cin;

int main(int argc, char* argv[]) {
#ifdef _MSC_VER
	freopen(".\\uva11340\\in.txt", "r", stdin);
#endif

	if (!cin) {
		std::cerr << "Failed to open file" << std::endl;
	}
	int n;
	cin >> n;
	while (n-- > 0) {
		int k, m; ;
		int map[256];
		for (auto& i : map) i = 0;
		cin >> k;
		cin.ignore();		
		for (std::string s; k > 0 && getline(cin, s); k--) {
			map[s[0]] = atoi(&s[1]);			
		}		
		cin >> m;
		cin.ignore();
		unsigned long long cost = 0;
		for (std::string s; m-- > 0 && getline(cin, s, '\n');) {
			for (unsigned char ch : s) cost += map[ch];
		}
		
		/*cin.ignore();
		unsigned char ch;
		for (int i = 0; i < m; i++) {
			while ((ch = cin.get()) != '\n' && cin) {
				//cal.append((int)ch);
				cost += map[(int)ch];
			}
		}*/

		std::cout << std::fixed << std::setprecision(2) << cost /100.0 << "$" << std::endl;
		//printf("%.2lf$\n", cost / 100.0);
	}
	return 0;
}
