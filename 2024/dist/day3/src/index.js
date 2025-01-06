"use strict";
// import { readFileSync } from 'fs';
// function parseInput(): any {
//     const input = readFileSync('././full_input.txt', 'utf-8').trim();
//     const regex = /mul\((\d+),(\d+)\)/g;
//     const dont = /don't/g
//     const doo = /do\b/g
//     let idx = 0 
//     let totalValue = 0;
//     let maxDoIndex = 1;
//     let match: RegExpExecArray | null;
//     while ((match = regex.exec(input)) !== null) {
//         const betweenText = input.substring(idx, match.index);
//         const donts = [...betweenText.matchAll(dont)];
//         const doos = [...betweenText.matchAll(doo)];
//         let maxDontIndex = donts.length > 0 ? Math.max(...donts.map(m => m.index)) : -1; 
//         maxDoIndex += doos.length > 0 ? Math.max(...doos.map(m => m.index)) : -1;
//         console.log(maxDoIndex, maxDontIndex);
//         if (maxDontIndex < maxDoIndex)
//         {totalValue += Number(match[1]) * Number(match[2])
//             maxDoIndex = 1;
//         }
//         else 
//         {
//             maxDoIndex = 0
//         };
//     }
//     console.log(totalValue);
// }
// parseInput();
