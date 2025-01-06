"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const fs_1 = require("fs");
const path_1 = __importDefault(require("path"));
function parseInput() {
    const filePath = path_1.default.join(__dirname, 'input.txt');
    const input = (0, fs_1.readFileSync)(filePath, 'utf-8').trim();
    const garden = input.split('\n').map(row => row.split(''));
    return garden;
}
const gardenMap = parseInput();
function calculatePlotCost(garden) {
    const visited = new Set();
    const plotPrices = [];
    const plotSides = [];
    for (let i = 0; i < garden.length; i++) {
        for (let j = 0; j < garden[0].length; j++) {
            const plotType = garden[i][j];
            const scores = { area: 0, perimeter: 0, plotType: plotType, sides: 0 };
            gardenDfs(i, j, plotType, garden, visited, scores);
            console.log(scores);
            plotPrices.push(scores.area * scores.perimeter);
        }
    }
    const plotTotal = plotPrices.reduce((num, idx) => num + idx, 0);
    const plotSidesTotal = plotSides.reduce((num, idx) => num + idx, 0);
    console.log("total plot sides: ", plotSidesTotal);
}
function gardenDfs(x, y, plotType, gardenMap, visited, scores) {
    const directions = [
        [0, 1],
        [1, 0],
        [0, -1],
        [-1, 0], //up
    ];
    if (x < 0 || y < 0 ||
        x >= gardenMap.length ||
        y >= gardenMap[0].length ||
        visited.has(`${x},${y}`) ||
        gardenMap[x][y] !== plotType) {
        return;
    }
    visited.add(`${x},${y}`);
    scores.area += 1;
    for (const direction of directions) {
        let adjacentX = x + direction[0];
        let adjacentY = y + direction[1];
        if (adjacentX < 0 || adjacentY < 0 || //if its going out of bounds
            adjacentX >= gardenMap.length ||
            adjacentX >= gardenMap[0].length ||
            gardenMap[adjacentX][adjacentY] !== plotType //if its the edge EEEAAA
        ) {
            scores.perimeter += 1;
            console.log(x, y, adjacentX, adjacentY);
            console.log(gardenMap[x][y], plotType);
            if (gardenMap[x][y] != plotType) {
                console.log("fired");
                scores.sides += 1;
            }
        }
    }
    for (const direction of directions) {
        let adjacentX = x + direction[0];
        let adjacentY = y + direction[1];
        gardenDfs(adjacentX, adjacentY, plotType, gardenMap, visited, scores);
    }
}
calculatePlotCost(gardenMap);
