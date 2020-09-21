// Problem ID:	10189
// Name:		Minesweeper
// URI:			https://uva.onlinejudge.org/external/101/10189.pdf

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
//std::ofstream cout("out.txt");
std::ifstream cin{ "p10189.txt" };
#else
#include <iostream>
using std::cin;
using std::cout;
#endif

struct cell {
	int i, j, on, n;
	cell(int i, int j, int on): i{i}, j{j}, on{on}, n(0) {
	}

	static cell create(int i, int j, int x) {
		return cell{ i, j, x };
	}
};

int main(int argc, char* argv[]) {
	if (!cin) {
		std::cerr << "Failed to open file" << std::endl;
	}
	int f = 0;
	while (true) {
		int n, m, i = 0, j = 0;
		char ch;
		cin >> n >> m;
		if (n == 0 && m == 0) break;
		std::vector<std::vector<cell>> grid;

		while (i < n) {
			grid.push_back(std::vector<cell>());
			for (int j = 0; j < m; j++) {
				cin >> ch;
				grid[i].push_back(cell::create(i, j, ch == '*' ? 1 : 0));
			}
			i++;
		}
				
		for (i = 0; i < n; i++) {
			for (j = 0; j < m; j++) {
				if (!grid[i][j].on) {
					for (int xdiff = -1; xdiff <= 1; xdiff++) {
						for (int ydiff = -1; ydiff <= 1; ydiff++) {
							int x = grid[i][j].i + xdiff, y = grid[i][j].j + ydiff;
							if (x >= 0 && y >= 0 && x < n && y < m) {
								if (grid[x][y].on) {
									grid[i][j].n++;
								}
							}
						}
					}
				}
			}
		}
		if (f > 0) {
			std::cout << std::endl;
		}
		std::cout << "Field #" << std::to_string(++f) << ":" << std::endl;

		for (i = 0; i < n; i++) {			
			for (j = 0; j < m; j++) {
				grid[i][j].on ? std::cout << "*" : std::cout << grid[i][j].n;
			}
			std::cout << std::endl;
		}		
	}
	getchar();
	return 0;
}