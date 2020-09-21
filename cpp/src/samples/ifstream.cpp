#include <fstream>
#include <iostream>
#include <string>
#include <sstream>
#include <vector>

using namespace std;
class vec {
	int _sz;
	double* _elm;
public:
	explicit vec(int sz): _sz(0) {
		_elm = new double[sz];
	}
	~vec() {
		delete[] _elm;
	}
};


static vector<string> readFile(const string& filePath) {
	//ifstream in(filePath, ios::in | ios::ate);
	auto fs = std::fstream();
	fs.exceptions(fs.exceptions() | std::ios::failbit);
	try {
		fs.open(filePath);
		vector<string> lines;
		string line;
		while (getline(fs, line)) {
			lines.push_back(line);
		}
		return lines;
	}
	catch (ios_base::failure& e) {
		throw runtime_error("File '" + filePath + "' not found.");
	}
}

int main(int argc, char* argv[]) {
	// if (strcmp(argv[1], "--help") == 0) {
 //        cerr << argv[0] << " [old-file [new-file]]" << endl;
 //        exit(EXIT_FAILURE);
 //    }

	try {
		readFile("moviesg.tx");
	}
	catch (exception& e) {
		cerr << "error: " << e.what() << '\n'; 
		return 1;
	}
	catch (...) {
		 cerr << "Oops: unknown exception!\n"; 
		return 2;
	}

	const istream &in(cin);
    ostream &out(cout);
	
    // Open input and output files
    if (argc > 1) {
        cerr << argv[1] << endl;
        ifstream _in("moviesg.txt", ios::in);
    	if (_in.is_open()) {
    	string line;
    		while (!getline(_in, line).eof()) {
    			std::istringstream iss(line);
    			std::cout << line << endl;
    		}
    		
		}
        //ifstream _in("moviesg.txt", ios::in | ios::binary);

    	
        // FIXME const in = _in;
        if (argc > 2) {
            cerr << argv[2] << endl;
            ofstream _out(argv[2], ios::out | ios::binary | ios::trunc);
            _out << _in.rdbuf(); // or: in >> out.rdbuf();
                                 // FIXME private operator= out=_out;
        } else {
            cout << _in.rdbuf();
        }
    } else {
        // FIXME Bus error cout << cin.rdbuf();  // or: cin >> cout.rdbuf();
    }

    // copy contents
    // XXX out << in.rdbuf();  // or: in >> out.rdbuf();

    if (out && in) {
        exit(EXIT_SUCCESS);
    } else {
        exit(EXIT_FAILURE);
    }
}
