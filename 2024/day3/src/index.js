"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fs_1 = require("fs");
function parseInput() {
    const input = (0, fs_1.readFileSync)('././test_input.txt', 'utf-8').trim();
    const regex = /mul\((\d+), (\d+)\)/g;
    let match;
    while ((match = regex.exec(input)) !== null) {
        console.log(match);
    }
    const multiplications = [];
    const corruptedEquations = input.split('\n').map(line => line.split(/\s+/).map(Number));
    // return reportLevels;
}
