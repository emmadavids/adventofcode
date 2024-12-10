import { readFileSync } from 'fs';

const symbols: ['+', '*', '|'] = ['+', '*', '|'];
function parseInput(): [number, number[]][] {
    const input = readFileSync('././full_input.txt', 'utf-8').trim();
    const calibrationEquations = input.trim()
        .split("\n")
        .map((line): [number, number[]]=> {
            const [sumTotalToProcess, numsToProcess] = line.split(":");
            const sumTotal = parseFloat(sumTotalToProcess);
            const nums = numsToProcess.split(" ").filter(n => n.trim() !== "").map(n => Number(n));
            return [sumTotal, nums];
    }
    ) 
    return calibrationEquations;
}

function calculatePermutations(operatorGaps: number )
{
    let combinations: string[] = [''];
    
    for (let i = 0; i < operatorGaps; i++) {
        const newCombinations: string[] = [];
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

function checkSum(operatorString: string[], numsToCalculate: number[], targetSum: number): number
{
    for (const element of operatorString) {
        let result = numsToCalculate[0]; 
        for (let i = 0; i < element.length; i++)
        {
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
            if (result == targetSum)
                { 
                    return result
                }       
    };
    return 0
}

function calculateCalibration(calibrationEquations : [number, number[]][] )
{
    let totalValue = 0;
    calibrationEquations.forEach(equation => {
        const sumTotal = equation[0];
        const operatorGaps = equation[1].length - 1;
        const operatorString = calculatePermutations(operatorGaps); 
        totalValue += checkSum(operatorString, equation[1], sumTotal);
    });
    console.log(totalValue)
};



calculateCalibration(calibrationEquations);