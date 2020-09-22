project(uva)
file(GLOB sourceFiles ${PROJECT_SOURCE_DIR}/*.cpp)
message ("Files:  ${sourceFiles}")
foreach (sourceFile ${sourceFiles})
	get_filename_component(appName ${sourceFile} NAME_WE)
	add_executable (${appName} ${sourceFile})
	install (TARGETS ${appName} DESTINATION bin)
endforeach ()

file(COPY "${PROJECT_SOURCE_DIR}/p12697.txt" DESTINATION .)
file(COPY "${PROJECT_SOURCE_DIR}/p12697_0.txt" DESTINATION .)
file(COPY "${PROJECT_SOURCE_DIR}/p12697_1.txt" DESTINATION .)
file(COPY "${PROJECT_SOURCE_DIR}/p12697_2.txt" DESTINATION .)

