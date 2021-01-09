cmake_minimum_required(VERSION 3.13)
project(samples LANGUAGES CXX)
#enable_testing()
set(cxx_sources
    next_permutation.cpp
    move_semantics.cpp
	vector.cpp
	priority_queue.cpp
	ifstream.cpp
    uniform_init.cpp
    allocation.cpp
    istream_iterator.cpp
    accumulate.cpp
)
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /std:c++17")
foreach(source ${cxx_sources})
    string(REGEX REPLACE "\.cpp$" "" program ${source})
    add_executable(${program} ${program}.cpp)
    #add_test(NAME ${program} COMMAND ${program})
endforeach()


set(RANGE 1)
set(STR "0")
while(RANGE LESS 100)
    MATH(EXPR RANGE "${RANGE}+1")
    set(STR "${STR} ${RANGE}")
endwhile()
file(APPEND ${CMAKE_BINARY_DIR}/testData.txt "${STR}")
add_compile_definitions(TEST_DATA_PATH="${CMAKE_BINARY_DIR}")