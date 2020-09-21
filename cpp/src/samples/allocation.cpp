#include <vector>

using VI = std::vector<int>;

struct MyData {
	int Count;
	int Max;
	//VI list;
};

// Placement new
// void* operator new(size_t size, void* p) {
// 	return p;
// }

void* operator new(size_t size, int x = 1, int y = 2) {
	return nullptr;
}


int main(int argc, char* argv[]) {
	auto p = new (1, 2) MyData;	
}



