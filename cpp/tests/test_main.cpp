#include "gtest/gtest.h"

TEST(testSuit2, testCase1) {
	EXPECT_EQ(1, 1);
}

TEST(testSuite2, testCase2) {
	EXPECT_TRUE(false);
}

//ASSERT_TRUE

TEST(Foo, Bar) {
    //...
    if (true)
        GTEST_SKIP_("message"); // or GTEST_SKIP() with no message
    //...
}