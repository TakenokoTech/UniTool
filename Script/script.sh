UNITY = /Applications/Unity/Hub/Editor/2019.3.7f1/Unity.app/Contents/MacOS/Unity

{UNITY} \
-batchmode \
-projectPath . \
-runTests \
-testPlatform playmode \
-logfile - \
# -logfile ./test-results/playmode.log \
-testResults ./test-results/playmode-results.xml

{UNITY} \
-batchmode \
-projectPath . \
-runTests \
-testPlatform editmode \
-logfile - \
# -logfile ./test-results/editmode.log \
-testResults ./test-results/editmode-results.xml
