// Problem ID:	11459
// Name:		Snakes and Ladders
// URI:			https://uva.onlinejudge.org/external/114/11459.pdf
#define DONLINE_JUDGE

//#ifdef _MSC_VER
//#define _CRT_SECURE_NO_WARNINGS
//#endif


#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include <numeric>
#include <string>
#include <queue>
#include <iterator>
#include <sstream>//
#include <tuple>
#include <iomanip>
#include <map>

#ifndef DONLINE_JUDGE
#include <fstream>
	//std::ifstream cin{ ".\\uva11459\\in.txt" };
	//std::ifstream cin{ ".\\uva11459\\in1.txt" };
	//std::ifstream cin{ ".\\uva11459\\in2.txt" };
	//std::ifstream cin{ ".\\uva11459\\in3.txt" };
	std::ifstream cin{ ".\\uva11459\\in4.txt" };
#else
#include <iostream>
using std::cout;
using std::cin;
#endif


struct Player {
	Player():pos{1}{}
	int pos;
};

class Game {
	std::map<int, int> _snakes;
	std::vector<Player> _players;
	int _numbOfPlayers; // number of players
	int _numbOfRolls; // number of dice rolls
	int _currentPlayer;
	bool _hasWinner;
public:
	Game(std::istream& is) : _numbOfRolls(0), _currentPlayer{-1}, _hasWinner{false} {
		int _numbOfSnakes /*snakes or ladders*/;
		is >> _numbOfPlayers >> _numbOfSnakes >> _numbOfRolls;
		_players.assign(_numbOfPlayers, Player());
		for (int j = 0; j < _numbOfSnakes; j++) {
			int beg, end;
			is >> beg >> end;
			_snakes.insert({beg, end});
		}
	}

	bool done() const {
		return _hasWinner || _numbOfRolls <= 0;
	}

	// Return the next player in turn
	int next() {
		return (_currentPlayer = (_currentPlayer+1) % _numbOfPlayers);
	}

	Player& get(int id) { return _players[id]; };
	
	// Move player p 
	void move(const int id, int steps) {
		if (!done()) {
			auto& p = get(id);
			p.pos = std::min(p.pos + steps, 100);
			const auto it = _snakes.find(_players[id].pos);
			if (it != _snakes.end()) {
				p.pos = it->second;
			}
			if (p.pos >= 100) {
				this->_hasWinner = true;
			}
			_numbOfRolls--;
		}
	}

	int numbOfPlayers() const {
		return _numbOfPlayers;
	}

	// Gets the number of moves left
	int totalMoves() const {	
		return _numbOfRolls;
	}
};


int main(int argc, char* argv[]) {
	if (!cin) {
		std::cerr << "Failed to open file" << std::endl;
	}
	int n, k;
	cin >> n;
	for (int i = 0; i < n; i++) {
		Game game(cin);
		while (game.numbOfPlayers() > 0 && !game.done()) {
			cin >> k;
			game.move(game.next(), k);
		}
		cin.ignore();
		std::string str;
		for (int i = game.totalMoves(); i > 0; i--) {
			std::getline(cin, str);
		}
		for (int i = 1, j = 0; j < game.numbOfPlayers(); i++, j++) {
			std::cout << "Position of player " << i << " is " << game.get(j).pos << "." << std::endl;
		}
	}
	//getchar();
	return 0;
}
