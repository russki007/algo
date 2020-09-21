#include "BinarySearchTree.h"
#include <iostream>
#include <fstream>
#include <vector>
#include <string>

using namespace std;

std::vector<int> readInput(istream& is) {
	int i = 0;
	string line;
	getline(is, line);
	vector<int> ints;
	while (is >> i) ints.push_back(i);
	return ints;
}
//
// struct Node {
// 	int data;
// 	Node* left;
// 	Node* right;
// };

using Node = BinarySearchTree<int>::BinaryNode;
bool checkBST(Node* root, int minValue, int maxValue) {
	return false;
}

bool checkBST(Node* root) {
	return false;
}

int main(int argc, char* argv[]) {
	try {
		ifstream fs("bst_input.txt");
		BinarySearchTree<int> bst;
		for(auto& i : readInput(fs)) {
			bst.insert(i);			
		}
		bst.printTree(std::cout);
		std::cout << (checkBST(bst.getRoot()) ? "True" : "False") << endl;
	}
	catch (exception& e) {
		cerr << "error:" << e.what() << '\n';
	}
	catch (...) {
	   cerr << "Oops: unknown exception!\n"; 
		return 2;
	}
}
