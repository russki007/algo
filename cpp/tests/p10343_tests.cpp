#include "gtest/gtest.h"
#include "gmock/gmock.h"

#include "../src/uva/p10343.cpp"


class Base64Ecoding : public testing::Test {
public:
	Base64Encoder encoder;
};

TEST(Base64Encoder, CanEncodeStringValue) {
	EXPECT_EQ(1, 2);
}


TEST(Base64Encoder, CanEncodeStringValue2) {
	//EXPECT_EQ(1, 2);
	ASSERT_THAT(3, testing::Eq(3));
}


TEST_F(Base64Ecoding, CanEncode) {
	//EXPECT_EQ("base6", encoder.getName());
}

