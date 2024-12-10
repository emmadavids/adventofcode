import { readFileSync } from 'fs';
const obstructionCoordinates = [];
const visitedPositions = [];
let guardStartingPostion = [];
function parseInput() {
    const input = readFileSync('././fullInput.txt', 'utf-8').trim();
    const labMap = input.trim()
        .split("\n")
        .map(line => line.split(""));
    for (let i = 0; i < labMap.length; i++) {
        for (let j = 0; j < labMap[i].length; j++) {
            if (labMap[i][j] == "#") {
                obstructionCoordinates.push([i, j]);
            }
            if (labMap[i][j] == "^") {
                guardStartingPostion = [i, j];
            }
        }
    }
    console.log(obstructionCoordinates);
    return labMap;
}
const isNotInObstructions = (x, y) => {
    return !obstructionCoordinates.some(obstacle => obstacle[0] === x && obstacle[1] === y);
};
const labMap = parseInput();
const directions = [
    [0, 1], //right
    [1, 0], //down
    [0, -1], //left
    [-1, 0], //up
];
//up ->  right --> down --> left --> up --> right
function traverseMap() {
    let count = 3;
    let direction = directions[count];
    let x = guardStartingPostion[0];
    let y = guardStartingPostion[1];
    while (x >= 0 && x < labMap.length && y >= 0 && y < labMap[0].length) {
        if ((isNotInObstructions(x, y))) {
            console.log([x, y]);
            visitedPositions.push([x, y]);
            x += direction[0];
            y += direction[1];
        }
        else {
            x -= direction[0];
            y -= direction[1];
            count++;
            if (count > 3) {
                count = 0;
            }
            direction = directions[count];
            x += direction[0];
            y += direction[1];
        }
        console.log(visitedPositions);
    }
    const uniquePositions = visitedPositions.filter((value, index, self) => self.findIndex(v => JSON.stringify(v) === JSON.stringify(value)) === index);
    console.log(uniquePositions);
    console.log(uniquePositions.length);
}
traverseMap();
