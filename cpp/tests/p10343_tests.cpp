#include "gtest/gtest.h"
#include "gmock/gmock.h"

#include "../src/uva/p10343.cpp"

using namespace std;
using SP = pair<string, string>;

static map<string, string> list {
	// SP{"Lorem ipsum dolor sit amet, consectetur adipiscing elit,
	// SP{"Neque laoreet suspendisse interdum consectetur libero id
	// SP{"Et sollicitudin ac orci phasellus egestas tellus rutrum 
	// SP{"Elementum nisi quis eleifend quam adipiscing vitae.", ""
	// SP{"Sodales neque sodales ut etiam sit amet nisl. Tincidunt 
	// SP{"Lacus vel facilisis volutpat est velit egestas dui id or
};

class Base64Ecoding : public testing::Test {
public:
	
	
	Base64Encoder encoder;
};

TEST(Base64Encoder, CanEncodeStringValue) {
	EXPECT_EQ(1, 2);


	int p[10], N = 3;
	for (int i = 0; i < N; i++) p[i] = i;
	do {
	for (int i = 0; i < N; i++) printf("%d ", p[i]);
	printf("\n");
	}
	while (next_permutation(p, p + N));

}


TEST(Base64Encoder, CanEncodeStringValue2) {
	//EXPECT_EQ(1, 2);
	ASSERT_THAT(3, testing::Eq(3));
}


TEST_F(Base64Ecoding, CanEncode) {
	//EXPECT_EQ("base6", encoder.getName());
}

