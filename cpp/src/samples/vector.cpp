#include <iostream>
#include <string>
#include <vector>

template <typename T>
std::ostream &operator<<(std::ostream &s, const std::vector<T> &v)
{
#if 1
    s.put('{');
    char comma[3] = {'\0', ' ', '\0'};  // default separator (empty)
    for (const auto& e : v)
    {
        s << comma << e;    //NOTE: print separator before item
        comma[0] = ',';     // change separator
    }
    return s << '}';
#else
    if (!v.empty()) {
        s << '{' << *v.begin();
        for (auto it = ++(v.begin()); it != v.end(); ++it) {
            s << ", " << *it;
        }
        s << '}' << std::endl;
    } else {
        s << "{}" << std::endl;
    }
    return s;
#endif
}

constexpr uint8_t  nDefaultAlpha = 0xFF;
constexpr uint32_t nDefaultPixel = (nDefaultAlpha << 24);

struct RGB {
    union {
        uint32_t n = nDefaultPixel;
        uint8_t r; uint8_t g; uint8_t b; uint8_t a;
    };
    RGB() {
        r = 0; g = 0; b = 0; a = nDefaultAlpha;
        std::cout << "Constructor" << std::endl;
    }
	RGB(uint8_t red, uint8_t green, uint8_t blue, uint8_t alpha = nDefaultAlpha) {
        n = red | (green << 8) | (blue << 16) | (alpha << 24);
        std::cout << "Constructor(r,g,b,a)=" << red << "," << green << "," << blue << "," << std::endl;
    }
	RGB(uint32_t p) {
        n = p;
        std::cout << "Constructor(p)" << std::endl;
    }

    RGB(const RGB& rhs) {
        std::cout << "Copy Constructor(p)" << std::endl;
    }

    ~RGB() {
            std::cout << "Destuctor()" << std::endl;
    }
};

int main()
{
    // c++11 initializer list syntax:
    std::vector<std::string> words1{"the", "frogurt", "is", "also", "cursed"};
    std::cout << "words1: " << words1 << std::endl;

    // words2 == words1
    std::vector<std::string> words2(words1.begin(), words1.end());
    std::cout << "words2: " << words2 << std::endl;

    // words3 == words1
    std::vector<std::string> words3(words1);
    std::cout << "words3: " << words3 << std::endl;

    // words4 is ["Mo", "Mo", "Mo", "Mo", "Mo"]
    std::vector<std::string> words4(5, "Mo");
    std::cout << "words4: " << words4 << std::endl;

    // ints is [0, 0, 0, 0, 0]
    std::vector<int> ints(5);
    std::cout << "ints: " << ints << std::endl;

    std::vector<int> empty;
    std::cout << "empty: " << empty << std::endl;
	
	using vi = std::vector<int>;
	vi vec{1, 2, 3, 4, 5, 6, 7, 8, 9};
	std::cout << vec << std::endl;	

    std::vector<RGB> vec1;
    for (int i = 0; i < 2; i++) {
        vec1.push_back(RGB(11, 11, 11));
    }
}

