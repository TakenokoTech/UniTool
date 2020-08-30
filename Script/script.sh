/Applications/Unity/Hub/Editor/2019.3.7f1/Unity.app/Contents/MacOS/Unity \
-batchmode \
-projectPath . \
-runTests \
-testPlatform playmode \
-logfile - \
-testResults ./test-results/playmode-results.xml
# -logfile ./test-results/playmode.log \

/Applications/Unity/Hub/Editor/2019.3.7f1/Unity.app/Contents/MacOS/Unity \
-batchmode \
-projectPath . \
-runTests \
-testPlatform editmode \
-logfile - \
-testResults ./test-results/editmode-results.xml
# -logfile ./test-results/editmode.log \