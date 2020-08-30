# Sometimes it's a README fix, or something like that - which isn't relevant for
# including in a project's CHANGELOG for example
declared_trivial = github.pr_title.include? "#trivial"

# Make it more obvious that a PR is a work in progress and shouldn't be merged yet
warn("PR is classed as Work in Progress") if github.pr_title.include? "[WIP]"

# Warn when there is a big PR
warn("Big PR") if git.lines_of_code > 500

# Convert Test Report
system("xsltproc Script/nunit-to-junit.xsl ./test-results/playmode-results.xml > ./test-results/playmode-results-junit.xml")
system("xsltproc Script/nunit-to-junit.xsl ./test-results/editmode-results.xml > ./test-results/editmode-results-junit.xml")

# Denger
`find . | grep ".*-results-junit.xml"`.split("\n").each do |path|
    junit.parse(path)
    junit.report
    # print(junit.tests)
    # print(junit.passes)
    # print(junit.failures)
end
