"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (k !== "default" && Object.prototype.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
    __setModuleDefault(result, mod);
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
const fs = __importStar(require("fs"));
const data = fs.readFileSync('././input/input.txt', 'utf-8');
let leftColumn = [];
let rightColumn = [];
const lines = data.split('\n');
lines.forEach(line => {
    const [left, right] = line.split(/\s+/).map(Number);
    {
        leftColumn.push(left);
        rightColumn.push(right);
    }
});
leftColumn.sort((a, b) => a - b);
rightColumn.sort((a, b) => a - b);
let total = 0;
leftColumn.forEach((leftValue, index) => {
    let difference = Math.abs(leftValue - rightColumn[index]);
    total += difference;
});
let totalSimilarityScore = 0;
leftColumn.forEach(item => {
    const count = rightColumn.filter(num => num === item).length;
    totalSimilarityScore += item * count;
});
console.log(totalSimilarityScore);
