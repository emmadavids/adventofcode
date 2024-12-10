import { readFileSync } from 'fs';
const symbols = ['+', '*', '|'];
function parseInput() {
    const input = readFileSync('././full_input.txt', 'utf-8').trim();
    const calibrationEquations = input.trim()
        .split("\n")
        .map((line) => {
        const [sumTotalToProcess, numsToProcess] = line.split(":");
        const sumTotal = parseFloat(sumTotalToProcess);
        const nums = numsToProcess.split(" ").filter(n => n.trim() !== "").map(n => Number(n));
        return [sumTotal, nums];
    });
    return calibrationEquations;
}
function calculatePermutations(operatorGaps) {
    let combinations = [''];
    for (let i = 0; i < operatorGaps; i++) {
        const newCombinations = [];
        for (const combo of combinations) {
            for (const symbol of symbols) {
                newCombinations.push(combo + symbol);
            }
        }
        combinations = newCombinations;
    }
    return combinations;
}
const calibrationEquations = parseInput();
calculatePermutations(4);
function checkSum(operatorString, numsToCalculate, targetSum) {
    for (const element of operatorString) {
        let result = numsToCalculate[0];
        for (let i = 0; i < element.length; i++) {
            if (element[i] == "*") {
                result *= numsToCalculate[i + 1];
            }
            if (element[i] == "+") {
                result += numsToCalculate[i + 1];
            }
            if (element[i] == "|") {
                const stringyNum = result.toString() + numsToCalculate[i + 1].toString();
                result = Number(stringyNum);
            }
        }
        if (result == targetSum) {
            return result;
        }
    }
    ;
    return 0;
}
function calculateCalibration(calibrationEquations) {
    let totalValue = 0;
    calibrationEquations.forEach(equation => {
        const sumTotal = equation[0];
        const operatorGaps = equation[1].length - 1;
        const operatorString = calculatePermutations(operatorGaps);
        totalValue += checkSum(operatorString, equation[1], sumTotal);
    });
    console.log(totalValue);
}
;
calculateCalibration(calibrationEquations);
