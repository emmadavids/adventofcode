"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fs_1 = require("fs");
function parseInput() {
    const input = (0, fs_1.readFileSync)('././full_input.txt', 'utf-8').trim();
    const wordSearch = input.trim()
        .split("\n")
        .map(line => line.split(""));
    return wordSearch;
}
const wordSearch = parseInput();
function findXmas(wordSearch) {
    const neighbouringCoordinates = [[-1, -1], [1, 1], [-1, 0], [0, -1], [0, 1], [1, 0], [1, -1], [-1, 1]];
    let xmasWordCount = 0;
    let xmasWords = [];
    for (let i = 0; i < wordSearch.length; i++) {
        for (let j = 0; j < wordSearch.length; j++) {
            if (wordSearch[i][j] == "X") {
                for (let q = 0; q < neighbouringCoordinates.length; q++) {
                    let letters = 3;
                    let word = [['X']];
                    let [directionY, directionX] = neighbouringCoordinates[q];
                    let x = i;
                    let y = j;
                    while (letters != 0) {
                        x += directionX;
                        y += directionY;
                        if (x >= 0 && y >= 0 && x < wordSearch.length && y < wordSearch[i].length) {
                            word.push([wordSearch[x][y]]);
                        }
                        else {
                            break;
                        }
                        if (!"XMAS".includes(word.flat().join(''))) {
                            break;
                        }
                        letters--;
                    }
                    if (word.flat().join('') == "XMAS") {
                        xmasWords.push(word.flat().join(''));
                        xmasWordCount++;
                    }
                }
                ;
            }
        }
    }
    console.log(xmasWordCount);
}
findXmas(wordSearch);
