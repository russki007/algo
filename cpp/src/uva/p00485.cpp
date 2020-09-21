// Problem ID:	485 
// Name:		Pascal's Triangle of Death
// URI:			https://uva.onlinejudge.org/external/4/485.pdf

#define DONLINE_JUDGE

//#include <cmath>
#include <cstdio>
//#include <vector>
//#include <algorithm>
//#include <numeric>
//#include <string>
//#include <queue>
//#include <iterator>
////#include <sstream>
//#include <tuple>
#include <iostream>
#include <vector>
#include <algorithm>
#include <string>
#include <numeric>


#ifndef DONLINE_JUDGE
#include <fstream>
std::ifstream cin{ "in.txt" };
using std::cout;
#else
#include <iostream>
using std::cin;
using std::cout;
#endif

template <typename T> class IComparable {
public:
	virtual ~IComparable() = default;
	virtual int compareTo(const T& obj) = 0;
};

class BigInt : public IComparable<BigInt> {
	std::vector<int> number;
	int base = 10;
	static int sign(int x) { return (x > 0) ? 1 : ((x < 0) ? -1 : 0); }
public:
	BigInt(): BigInt(0) {}
	BigInt(std::string s) {
		auto& b = number;
		std::for_each(s.rbegin(), s.rend(), [&b](char& ch)
		{
			if (ch >= '0' && ch <= '9') b.push_back(ch - '0');
		});
	}

	BigInt(long long n) {
		while (n) {
			number.push_back(n%base);
			n /= base;
		}
	}

	BigInt operator+(const BigInt& rhs) const {
		BigInt num;		
		int curry = 0, value = 0, i = 0;
		for (i = 0; i < std::max(rhs.number.size(), number.size()); i++) {
			value = ((i < rhs.number.size()) ? rhs.number[i] : 0) +  ((i < number.size()) ? number[i] : 0) + curry;
			curry = value / base;
			if (i >= num.number.size()) num.number.push_back(0);
			num.number[i] = value % base;
		}		
		if (curry > 0) {
			num.number.push_back(curry);			
		}
		return num;
	}
	int compareTo(const BigInt& obj) override {
		if (number.size() > obj.number.size()) return 1;
		if (number.size() < obj.number.size()) return -1;
		for (int i = 0; i < number.size(); i++) {
			int sign = BigInt::sign(number[i] - obj.number[i]);
			if (sign != 0) return sign;
		}
		return 0;
	}
	operator std::string() {
		return toString();
	}
	std::string toString() {
		std::string str;
		std::for_each(number.rbegin(), number.rend(), [&](int& n) { str += std::to_string(n); });
		return str;
	}
};

inline BigInt c(int n, int r) {
	static std::vector<std::vector<BigInt>> memo{ { 1 },{ 1, 1 } };
	if (r > n) throw std::invalid_argument("Invalid argument");
	if (memo.size() > n && memo[n].size() > r && memo[n][r].compareTo(1) > 0) return memo[n][r];
	if (n <= 1 || n == r || r <= 0) return 1;
	auto p = c(n - 1, r - 1) + c(n - 1, r);
	if (n >= memo.size()) {
		memo.push_back(std::vector<BigInt>(n + 1, 0));
	}
	memo[n][r] = p;
	return p;
}

void cc(std::vector<BigInt>& arr) {
	std::vector<BigInt> dest{ 1 };
	std::transform(arr.begin(), arr.end(), std::back_inserter(dest), [&arr](auto e) { auto x = arr[0] + e; arr[0] = e; return x; });
	dest.push_back(1);
	cc(dest);
}

//int main(int argc, char* argv[]) {
//	std::vector<BigInt> arr{ 1 };
//	BigInt max{ "1,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000" };
//	auto func = [](std::vector<BigInt> arr, auto callback) {
//		auto pos = std::find_if(arr.begin(), arr.end(), [&max](const auto* elm) { return elm->compareTo(max) >= 0;  });
//		if (pos != arr.end()) return;
//		std::vector<BigInt> dest{ 1 };
//		std::transform(arr.begin(), arr.end(), std::back_inserter(dest), [&arr](auto e) { auto x = arr[0] + e; arr[0] = e; return x; });
//		dest.push_back(1);
//		func(dest, callback);
//	};
//	func(arr, [](const std::vector<BigInt>& v) {
//		std::string str = std::accumulate(v.begin(), v.end(), std::string{}, [](const std::string& a, auto b) {
//			return a + (a.length() > 0 ? "," : "") + b.toString();
//		});
//		cout << str << "\n";
//	});
//}

int main(int argc, char* argv[]) {
	int n = 0;
	BigInt max {"1,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000,000"};
	bool stop = false;
	while (!stop) {
		for (auto i = 0; i <= n; i++) {
			auto x = c(n, i);
			if (x.compareTo(max) >= 0) {
				stop = true;
			}
			if (i > 0) cout << " ";
			cout << x.toString();			
		}
		n++;
		cout << "\n";
	}	
	return 0;
}