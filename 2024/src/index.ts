import * as fs from 'fs';

const data = fs.readFileSync('././input/input.txt', 'utf-8');

let leftColumn: number[] = [];
let rightColumn: number[] = [];

const lines = data.split('\n');
lines.forEach(line => {
  const [left, right] = line.split(/\s+/).map(Number);
  {
    leftColumn.push(left);
    rightColumn.push(right);
  }
});

leftColumn.sort((a, b) => a - b);  
rightColumn.sort((a, b) => a - b)

let total = 0;
leftColumn.forEach((leftValue, index) => { 
  let difference: number = Math.abs(leftValue - rightColumn[index]);
total += difference;})

let totalSimilarityScore = 0;
leftColumn.forEach(item => {
  const count = rightColumn.filter(num => num === item).length
  totalSimilarityScore += item * count;
})


console.log(totalSimilarityScore);

