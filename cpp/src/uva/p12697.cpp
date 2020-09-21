// Problem ID: 12697
// Name: Minimal Subarray Length		
// URI:	https://uva.onlinejudge.org/external/126/12697.pdf		

//#define DONLINE_JUDGE
#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include <numeric>
#include <string>
#include <climits>
#include <queue>
#include <iterator>
#include <sstream>
#include <tuple>

#include <vector>
#include <cstdio>
#include <cstring>
#include <queue>
#include <cctype>
#include <cmath>
#include <algorithm>
#include <iostream>
#include <bitset>
#include <map>
#include <complex>
#include <ctime>
#include <numeric>
#include <set>
#include <cassert>


#ifndef DONLINE_JUDGE
#include <fstream>
//std::ifstream cin{ "p12697.txt" };
//std::ifstream cin{ "p12697_0.txt" };
//std::ifstream cin{ "p12697_1.txt" };
std::ifstream cin{ "p12697_2.txt" };
#else
#include <iostream>
using std::cin;
using std::cout;
#endif

typedef std::vector<int> vi;
typedef long long ll;
typedef std::pair<ll, int> pi;

class Solution {
public:
	static int minSubArrayLen(int s, vi& nums) {
		int min = INT_MAX;
		for (int i = 0; i < nums.size(); i++) {
			ll sum = 0l;
			for (int j = i; j < nums.size(); j++) {
				sum += nums[j];
				if (sum >= s) {
					min = std::min(min, j - i + 1);
					break;
				}
			}
		}

		return min != INT_MAX ? min : -1;
	}
};

class SolutionV2 {
public:
	static int minSubArrayLen(int s, vi& nums)
	{
		int n = nums.size();
		if (n == 0)
			return 0;
		int ans = INT_MAX;
		vi sums(n);
		sums[0] = nums[0];
		for (int i = 1; i < n; i++)
			sums[i] = sums[i - 1] + nums[i];
		for (int i = 0; i < n; i++) {
			for (int j = i; j < n; j++) {
				int sum = sums[j] - sums[i] + nums[i];
				if (sum >= s) {
					ans = std::min(ans, (j - i + 1));
					break; //Found the smallest subarray with sum>=s starting with index i, hence move to next index
				}
			}
		}
		return (ans != INT_MAX) ? ans : -1;
	}
};





class SolutionV3 {
public:
	static int minSubArrayLen(int X, vi& nums) {
		int besti = 1e9;
		int n = nums.size();
		vi ACC(n);
		ACC[0] = nums[0];
		for (int i = 1; i < n; i++) {
			ACC[i] = ACC[i - 1] + nums[i];
		}
		std::priority_queue< pi, std::vector<pi>, std::greater<pi>> pq;
		pq.push(pi(ACC[0], 0));
		for (int i = 0; i < n; i++) {
			while (!pq.empty() && ACC[i] - pq.top().first >= X) {
				besti = std::min(besti, i - pq.top().second);
				pq.pop();
			}
			pq.push(pi(ACC[i], i));
		}
		return besti > n ? -1 : besti;
	}
};

int main(int argc, char* argv[]) {
	int t, n, x, e;
	cin >> t;
	while (t-- > 0) {
		cin >> n >> x;
		vi v(n);
		for (int i = 0; i < n; i++) cin >> v[i];
		//std::cout << SolutionV3::minSubArrayLen(x, v) << "\n";
		std::cout << Solution::minSubArrayLen(x, v) << "\n";
	}
#ifndef DONLINE_JUDGE
	getchar();
#endif
}