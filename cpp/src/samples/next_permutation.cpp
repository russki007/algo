#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
#include <iterator>

using namespace std;

int main(int argc, char* argv[]) {
	
	vector<char> v{'a', 'b', 'c'};
	do {
		cout << v[0] << v[1] << v[2] << endl;
	} while (next_permutation(v.begin(), v.end()));

	int p[10], N = 3;
	for (int i = 0; i < N; i++) p[i] = i;
	do {
		for (int i = 0; i < N; i++) printf("%d ", p[i]);
			printf("\n");
	} while (next_permutation(p, p + N));

	cout << "================="	<< endl;
	vector<string> vec(istream_iterator<string>{cin}, {} /*EOS*/);
	sort(begin(vec), end(vec));
	copy(begin(vec), end(vec), ostream_iterator<string>{cout, " "});
	do {
		copy(begin(vec), end(vec), ostream_iterator<string>{cout, " "});
		cout << '\n';		
	} while (next_permutation(begin(vec), end(vec)));
	
}
