#include <iostream>
#include <vector>
#include <numeric>
#include <iomanip>

using namespace std;

double mean(vector<int> v) {
	int sum = accumulate(v.begin(), v.end(), 0)/v.size();
	return double(sum)/v.size();
}

/*double mean(vector<int> a) {
    return (static_cast<double>(accumulate(begin(a), end(a), 0))) / static_cast<int>(a.size());
}*/

int main(int argc, char* argv[]) {
	int n;
    cin >> n;
    
    vector<int> a(n);
    
    for (int i = 0; i < n; i++) {
        cin >> a[i];
    }
    
    double m = mean(a);
    double s = 0;
    
    for (int e : a) {
        s += (e - m) * (e - m);
    }
    
    s /= n;
    
    cout << setprecision(1) << fixed << sqrt(s);
    
    return 0;
}

int max(vector<int> v) {
    auto m = mean(v);
    return accumulate(begin(v), end(v), 0, [&](const int a, const int b) {
        return a > b ? a : b;
    });
}