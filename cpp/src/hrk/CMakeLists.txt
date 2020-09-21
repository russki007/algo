cmake_minimum_required(VERSION 3.13)
project(samples LANGUAGES CXX)
enable_testing()
set(cxx_sources
	bst.cpp
)

foreach(source ${cxx_sources})
    string(REGEX REPLACE "\.cpp$" "" program ${source})
    add_executable(${program} ${program}.cpp)
    #set_target_properties(${program} PROPERTIES CXX_STANDARD 17)
    add_test(NAME ${program} COMMAND ${program})
endforeach()

file(COPY "${PROJECT_SOURCE_DIR}/bst_input.txt" DESTINATION .)

include(CMakePrintSystemInformation)
message("CMAKE_CXX_LIBRARY_ARCHITECTURE ${CMAKE_CXX_LIBRARY_ARCHITECTURE}")