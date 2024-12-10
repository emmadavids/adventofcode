"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const fs_1 = require("fs");
const path_1 = __importDefault(require("path"));
function parseInput() {
    const filePath = path_1.default.join(__dirname, 'testInput.txt');
    const input = (0, fs_1.readFileSync)(filePath, 'utf-8').trim();
    const files = input.split("")
        .map(x => Number(x));
    let idCounter = 0;
    let fileSystem = [];
    for (let i = 0; i < files.length; i++) {
        if (i % 2 == 0) {
            for (let f = 0; f < files[i]; f++) {
                fileSystem.push(idCounter);
            }
            idCounter++;
        }
        else {
            for (let f = 0; f < files[i]; f++) {
                fileSystem.push(".");
            }
        }
    }
    console.log(fileSystem);
    return fileSystem;
}
;
function moveFilesIntoSpaces(fileSystem) {
    let spaceIndex = fileSystem.indexOf(".");
    while (spaceIndex != -1) {
        const lastFile = fileSystem.pop(); //take the last element off 
        // if (lastFile === ".") {
        //     fileSystem.pop(); 
        // }
        if (lastFile != ".") {
            fileSystem.splice(spaceIndex, 1, lastFile);
        } //put it in where theres a space only if its not a dot
        spaceIndex = fileSystem.indexOf(".");
    }
    console.log(fileSystem);
}
const fileSystem = parseInput();
moveFilesIntoSpaces(fileSystem);
let checkSum = 0;
let idCounter = 0; //sorry bad DRY i know
fileSystem.forEach((element) => {
    checkSum += idCounter * element;
    idCounter++;
});
console.log(checkSum);
