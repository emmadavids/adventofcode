import { readFileSync } from 'fs';
function parseInput() {
    const input = readFileSync('././input.txt', 'utf-8').trim();
    const reportLevels = input.split('\n').map(line => line.split(/\s+/).map(Number));
    return reportLevels;
}
let totalValue = 0;
const reportLevels = parseInput();
reportLevels.forEach((report) => {
    const idx = testSafety(report);
    console.log(report);
    if (idx === -1) {
        totalValue++;
        console.log("success!");
    }
    else {
        const modifiedReport = [...report];
        modifiedReport.splice(idx, 1);
        const alternativeModifiedReport = [...report];
        const alternativeModifiedReport2 = [...report];
        alternativeModifiedReport.splice(idx + 1, 1);
        alternativeModifiedReport2.splice(idx - 1, 1);
        console.log(modifiedReport);
        if (testSafety(modifiedReport) === -1) {
            totalValue++;
        }
        else if (testSafety(alternativeModifiedReport) === -1) {
            totalValue++;
        }
        else if (testSafety(alternativeModifiedReport2) === -1) {
            totalValue++;
        }
    }
});
function testSafety(report) {
    let isIncreasing = report[0] < report[1];
    for (let idx = 0; idx < report.length - 1; idx++) {
        if (report[idx + 1] !== undefined) {
            if (isIncreasing) {
                //make sure the second number is higher by less than 3 and more than 1
                let difference = report[idx + 1] - report[idx];
                if (difference > 3 || difference < 1) {
                    return idx;
                }
            }
            else {
                //if its not increasing make sure its lower by less than 3 and more than 1
                let difference = report[idx] - report[idx + 1];
                if (difference > 3 || difference < 1) {
                    return idx;
                }
            }
        }
    }
    return -1;
}
