#include <algorithm>
#include <fstream>
#include <iterator>
#include <string>
#include <vector>
#include <iostream>
#include <filesystem>
#include <numeric>


using namespace std;
using namespace filesystem;

int main(int argc, char* argv[]) {
	istream_iterator<int> in(cin), eof;
	cout << accumulate(in, eof, 0) << endl;


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
