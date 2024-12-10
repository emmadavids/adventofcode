import { readFileSync } from 'fs';

function parseInput(): any {
    const input = readFileSync('././testInput.txt', 'utf-8').trim();
    const [pageOrderingRulesUnprocessed, updatePageNumbersUnprocessed] = input.split(/^\s*$/m, 2);
    const pageOrderingRules = pageOrderingRulesUnprocessed.trim()
                            .split("\n")
                            .map(line => line.split('|')
                            .map(x => Number(x)));

    const rulesDictionary: { [key: number]: number[] } = pageOrderingRules.reduce((dict, [first, second]) => {
        if (!dict[first]) {
            dict[first] = []; 
        }
        dict[first].push(second); 
        return dict;
    }, {} as { [key: number]: number[] });

    const updatePageNumbers = updatePageNumbersUnprocessed.trim().split("\n")
                                .map(line => line.split(',')
                                .map(x => Number(x)));

    return [rulesDictionary, updatePageNumbers]
}

function sortCorrectlyOrderedUpdates(
    rulesDictionary: { [key: number]: number[] }, 
    updates: number[][]
): [number[][], number[][]] {
    let orderedPages : number[][] = [];
    let unorderedPages : number[][] = [];
    updates.forEach(line => {
        let isValidLine = true; 
        for (let i = 0; i < line.length -1; i ++)
        {
            const rightNums = rulesDictionary[line[i]]
            if (rightNums == undefined)
            {
                isValidLine = false;
                break;
            }
            const subsequentNums = line.slice(i + 1);
            const missingNums = subsequentNums.filter(x => !rightNums.includes(x));
            if (missingNums.length > 0)
            {
                isValidLine = false;
            }
        }
        if (isValidLine) {
            orderedPages.push(line);
        }
        else 
        { unorderedPages.push(line)}
    })

    return [orderedPages, unorderedPages]
};

const [rulesDictionary, updatePageNumbers] = parseInput();
const [orderedPages, unOrderedPages] = sortCorrectlyOrderedUpdates(rulesDictionary, updatePageNumbers);
let totalValue = 0;
let totalUnorderedValue = 0;
orderedPages.forEach(x => {
    const middle = x[Math.round((x.length - 1) / 2)]
    totalValue += middle;
})

// const sortedPages = unOrderedPages.map(element => {
//     const sorted = sortArrayByKeyValueRelation(element, rulesDictionary);
//     return sorted
// });

// sortedPages.forEach(x => {
//     const middle = x[Math.round((x.length - 1) / 2)]
//     totalUnorderedValue += middle;
// }
// )
console.log(totalValue);
console.log(totalUnorderedValue);