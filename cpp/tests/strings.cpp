#include "gtest/gtest.h"
#include <string>
#include <numeric>
#include <iterator>

using namespace std;

std::string toLower(const std::string& str) {
	auto s = std::string(str);
	std::transform(s.begin(), s.end(), s.begin(),
		[](unsigned char c) { return std::tolower(c); });

	/*for (auto i = s.begin(); i < s.end(); i++)
    {
      *i = std::tolower(static_cast<unsigned char>(*i));
    }*/
	int chars[256];
	std::iota(begin(chars), end(chars), 0);
	return s;
}


TEST(String, toLower) {
	EXPECT_TRUE(toLower("A").compare("A") == 0) << "Should be lowered";
}
