#include <algorithm>
#include <fstream>
#include <iterator>
#include <string>
#include <vector>
#include <iostream>
#include <filesystem>


using namespace std;
using namespace filesystem;

int main(int argc, char* argv[]) {
	path testDataPath { canonical("../../testData.txt") };
	if (argc >= 2) {
		testDataPath = path(argv[1]);
	}
	if (!exists(testDataPath)) {
		cout << "File " << testDataPath << " does not exits.\n";
		return 1;
	}
	vector<string> vec;
	ifstream stm( testDataPath);
	copy(istream_iterator<string>{stm}, {}, back_inserter(vec));
	return 0;
}
