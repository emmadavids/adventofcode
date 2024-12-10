import { readFileSync } from 'fs';
function parseInput() {
    const input = readFileSync('././testInput.txt', 'utf-8').trim();
    const files = input.split("")
        .map(x => Number(x));
    let idCounter = 0;
    let fileSystem = [];
    for (let i = 0; i < files.length; i++) {
        if (files[i] % 2 !== 0) {
            for (let f = 0; f < files[i]; f++) {
                fileSystem.push(idCounter);
            }
        }
        else {
            for (let f = 0; f < files[i]; f++) {
                fileSystem.push(".");
            }
        }
    }
    return fileSystem;
}
;
function moveFilesIntoSpaces(fileSystem) {
    let spaceIndex = fileSystem.indexOf(".");
    while (spaceIndex != -1) {
        const lastFile = fileSystem.pop();
        fileSystem.splice(spaceIndex, 1, lastFile);
        spaceIndex = fileSystem.indexOf(".");
    }
}
const fileSystem = parseInput();
moveFilesIntoSpaces(fileSystem);
console.log(fileSystem);
