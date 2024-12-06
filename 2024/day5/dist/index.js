"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fs_1 = require("fs");
function parseInput() {
    const input = (0, fs_1.readFileSync)('././full_input.txt', 'utf-8').trim();
    const [pageOrderingRulesUnprocessed, updatePageNumbersUnprocessed] = input.split(/^\s*$/m, 2);
    const pageOrderingRules = pageOrderingRulesUnprocessed.trim()
        .split("\n")
        .map(line => line.split('|')
        .map(x => Number(x)));
    const rulesDictionary = pageOrderingRules.reduce((dict, [first, second]) => {
        if (!dict[first]) {
            dict[first] = [];
        }
        dict[first].push(second);
        return dict;
    }, {});
    const updatePageNumbers = updatePageNumbersUnprocessed.trim().split("\n")
        .map(line => line.split(',')
        .map(x => Number(x)));
    return [rulesDictionary, updatePageNumbers];
}
function sortCorrectlyOrderedUpdates(rulesDictionary, updates) {
    let orderedPages = [];
    let unorderedPages = [];
    updates.forEach(line => {
        let isValidLine = true;
        for (let i = 0; i < line.length - 1; i++) {
            const rightNums = rulesDictionary[line[i]];
            if (rightNums == undefined) {
                isValidLine = false;
                break;
            }
            const subsequentNums = line.slice(i + 1);
            const missingNums = subsequentNums.filter(x => !rightNums.includes(x));
            if (missingNums.length > 0) {
                isValidLine = false;
            }
        }
        if (isValidLine) {
            orderedPages.push(line);
        }
        else {
            unorderedPages.push(line);
        }
    });
    return [orderedPages, unorderedPages];
}
;
const [rulesDictionary, updatePageNumbers] = parseInput();
const [orderedPages, unOrderedPages] = sortCorrectlyOrderedUpdates(rulesDictionary, updatePageNumbers);
let totalValue = 0;
let totalUnorderedValue = 0;
orderedPages.forEach(x => {
    const middle = x[Math.round((x.length - 1) / 2)];
    totalValue += middle;
});
function sortArrayByKeyValueRelation(arr, rulesDictionary) {
    const valueToKeyMap = {};
    for (const [key, values] of Object.entries(rulesDictionary)) {
        values.forEach(value => {
            if (!valueToKeyMap[value]) {
                valueToKeyMap[value] = [];
            }
            valueToKeyMap[value].push(Number(key));
        });
    }
    return arr.sort((a, b) => {
        if (valueToKeyMap[b] && valueToKeyMap[b].includes(a)) {
            return -1;
        }
        if (valueToKeyMap[a] && valueToKeyMap[a].includes(b)) {
            return 1;
        }
        return 0;
    });
}
const sortedPages = unOrderedPages.map(element => {
    const sorted = sortArrayByKeyValueRelation(element, rulesDictionary);
    return sorted;
});
sortedPages.forEach(x => {
    const middle = x[Math.round((x.length - 1) / 2)];
    totalUnorderedValue += middle;
});
console.log(totalValue);
console.log(totalUnorderedValue);
