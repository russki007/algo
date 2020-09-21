1. How define preprocessor macro through CMake?
```
add_compile_definitions(TEST_DATA_PATH="${CMAKE_BINARY_DIR}")
2. Enabling C++XX And Later In CMake
```
set(CMAKE_CXX_STANDARD 11) # Valid values for CMAKE_CXX_STANDARD 98,11,14,17,20 
set(CMAKE_CXX_STANDARD_REQUIRED ON) # Prevents fall back to the latest supported compiler
```

3. [CMake 3 Tools](https://github.com/CLIUtils/cmake) e.g. AddGoogleTest

## CMake Wellknow Properties
PROJECT_SOURCE_DIR
1. [CMAKE_BINARY_DIR](https://cmake.org/cmake/help/v3.15/variable/CMAKE_BINARY_DIR.html)  
2. [CMAKE_BUILD_TYPE](https://cmake.org/cmake/help/latest/variable/CMAKE_BUILD_TYPE.html)
PROJECT_NAME


# Dev Env.Setup
## Vcpkg
Vcpkg is required to download project dependencies. To get started, first clone vcpkg to a location on your system and run the bootstrapping script.



```
git clone https://github.com/Microsoft/vcpkg.git
cd vcpkg # Keep note of the location of this directory for the next step
Windows> .\bootstrap-vcpkg.bat
Linux/macOS:~/$ ./bootstrap-vcpkg.sh
```

Next, define the VCPKG_ROOT environment variable and add the vcpkg command to your path. You will probably want to persist these changes, so it's recommended to add/edit them via the Windows "System Properties" control panel, 
or via your .profile file on Linux/macOS.
WIN32
```bat
 set VCPKG_ROOT=C:\path\to\vcpkg
 set PATH=%PATH%;%VCPKG_ROOT%
UNIX
 ```

 ```sh
 export VCPKG_ROOT=/path/to/vcpkg
 export PATH=$PATH:$VCPKG_ROOT
 ```

Finally, install the project dependencies with vcpkg.
```
set VCPKG_DEFAULT_TRIPLET=x64-windows-static
vcpkg  install
```



#Building and Testing
## Building the project
Ensure `VCPKG_ROOT` environment varaible is set. 

```sh
mkdir build
cd build
cmake ..
cmake --build .
```

#### Testing the project
Tests are executed via the `ctest` command included with CMake. From the repo root, run:

```sh
cd build
ctest -C Debug

## Refernces
### Unit Tests
[Google Tests Discovery in CMake](https://blog.kitware.com/dynamic-google-test-discovery-in-cmake-3-10/#:~:text=CTest%20is%20a%20tool%20for,for%20writing%20individual%20C%2B%2B%20tests.&text=Even%20in%20the%20case%20of,for%20submitting%20results%20to%20CDash.)
1. CTest and Google test are complimentry
2. CTest is testing tool distributed with CMake
3. enable_testing() - adding testing support to project
2. Use add_test to register GTest with CTest

```
mkdir build && cd build
cmake ..
ctest
```

## VCPKG Integration
https://vcpkg.readthedocs.io/en/latest/users/integration/

if(DEFINED ENV{VCPKG_ROOT} AND NOT DEFINED CMAKE_TOOLCHAIN_FILE)
  set(CMAKE_TOOLCHAIN_FILE "$ENV{VCPKG_ROOT}/scripts/buildsystems/vcpkg.cmake"
      CACHE STRING "")
elseif(DEFINED ENV{VCPKG_INSTALLATION_ROOT} AND NOT DEFINED CMAKE_TOOLCHAIN_FILE)
  set(CMAKE_TOOLCHAIN_FILE "$ENV{VCPKG_INSTALLATION_ROOT}/scripts/buildsystems/vcpkg.cmake"
      CACHE STRING "")
endif()
if(DEFINED ENV{VCPKG_DEFAULT_TRIPLET} AND NOT DEFINED VCPKG_TARGET_TRIPLET)
  set(VCPKG_TARGET_TRIPLET "$ENV{VCPKG_DEFAULT_TRIPLET}" CACHE STRING "")
endif()



If(DEFINED ENV{VCPKG_ROOT} AND NOT DEFINED CMAKE_TOOLCHAIN_FILE)
    set(VCPKG_ROOT "$ENV{VCPKG_ROOT}")
    message(STATUS "VCPKG_ROOT=${VCPKG_ROOT}")
    set(CMAKE_TOOLCHAIN_FILE "${VCPKG_ROOT}/scripts/buildsystems/vcpkg.cmake" CACHE FILEPATH "")
endif()




## CMakeSettings.json
[Customize CMake build settings](https://docs.microsoft.com/en-us/cpp/build/customize-cmake-settings?view=vs-2019)
[CMakeSettings.json schema reference](https://docs.microsoft.com/en-us/cpp/build/cmakesettings-reference?view=vs-2019)
1. cmakeToolchain - DCMAKE_TOOLCHAIN_FILE = <filepath>". VS uses the [vcpkg toolchain file](https://github.com/microsoft/vcpkg/blob/master/docs/examples/installing-and-using-packages.md#cmake)
 if this setting is unspecified.
2.  "buildRoot":  "${env.LOCALAPPDATA}\\CMakeBuild\\${workspaceHash}\\build\\${name}"
     "buildRoot": "${env.USERPROFILE}\\CMakeBuilds\\${workspaceHash}\\build\\${name}",
3. "installRoot" - pecifies the directory in which CMake generates install targets

upported macros include ${workspaceRoot}, ${workspaceHash}, ${projectFile}, ${projectDir}, ${thisFile}, ${thisFileDir}, ${name}, ${generator}, ${env.VARIABLE}.

e.g

"${env.USERPROFILE}\\CMakeBuilds\\${workspaceHash}\\install\\${name}",
      

```json
{
  "configurations": [
    {
      "name": "x64-DebugWithTests",  \\ <!-- Configuration name, ${name} macro to compose other property values such as paths 
      "generator": "Ninja",
      "configurationType": "Debug", \\ <!-- Configuraiton Type. e.g Debug, Release. Mapps to CMAKE_BUILD_TYPE.
      "inheritEnvironments": [ "msvc_x64_x64" ],
      "buildRoot": "${projectDir}\\out\\build\\${name}", <!-- Mapps to CMAKE_BINARY_DIR and specifies where to create the CMake cache
      "installRoot": "${projectDir}\\out\\install\\${name}",
      "cmakeCommandArgs": "-DINSTALL_GTEST=OFF -DBUILD_TESTING=ON -DBUILD_CURL_TRANSPORT=ON -DBUILD_STORAGE_SAMPLES=ON",
      "buildCommandArgs": "-v -m -v:minimal",
      "ctestCommandArgs": "",
      // "cmakeToolchain" <!-- Path to toolchain file.  
      "variables": [
        {
          "name": "VCPKG_TARGET_TRIPLET",
          "value": "x64-windows-static",
          "type": "STRING"
        },

        {
          "name": "CMAKE_TOOLCHAIN_FILE",
          "value": "${env.USERPROFILE}\\.vcpkg\\scripts\\buildsystems\\vcpkg.cmake",
          "type": "STRING"
        }

      ]
    },
    {
      "name": "x86-Debug",
      "generator": "Ninja",
      "configurationType": "Debug",
      "buildRoot": "${projectDir}\\out\\build\\${name}",
      "installRoot": "${projectDir}\\out\\install\\${name}",
      "cmakeCommandArgs": "",
      "buildCommandArgs": "",
      "ctestCommandArgs": "",
      "inheritEnvironments": [ "msvc_x86" ],
      "variables": [
        {
          "name": "VCPKG_TARGET_TRIPLET",
          "value": "x86-windows-static",
          "type": "STRING"
        }
      ]
    }
  ]
}
```

