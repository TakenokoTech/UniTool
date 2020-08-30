`find . | grep ".*-results.xml"`.split("\n").each do |path|
    junit.parse(path)
    junit.report
end
