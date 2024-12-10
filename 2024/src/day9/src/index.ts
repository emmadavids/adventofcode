import { readFileSync } from 'fs';
import path from 'path';

function parseInput(): any {
    const filePath = path.join(__dirname, 'testInput.txt'); 
    const input = readFileSync(filePath, 'utf-8').trim();
    const files = input.split("")
                            .map(x => Number(x))
    let idCounter = 0;    
    let fileSystem : any[]= [];
    for (let i = 0; i < files.length; i++)        
        {
            if (i % 2 == 0)
            {
                for (let f = 0; f < files[i]; f++) 
                { 
                    fileSystem.push(idCounter); 
                }
                idCounter ++;
            }
            else 
            { 
                for (let f = 0; f < files[i]; f++) 
                { fileSystem.push(".");  }
            }
        }           
        console.log(fileSystem)
        return fileSystem
};

function moveFilesIntoSpaces(fileSystem: any)
{
    let spaceIndex = fileSystem.indexOf(".")
    while (spaceIndex != -1)
    {
        const lastFile = fileSystem.pop(); 
        if (lastFile != ".")
        {
            fileSystem.splice(spaceIndex, 1, lastFile)
        }
        spaceIndex = fileSystem.indexOf(".")
    }
    console.log(fileSystem);
}

const fileSystem = parseInput();
moveFilesIntoSpaces(fileSystem);
let checkSum = 0
let idCounter = 0; //sorry bad DRY i know

fileSystem.forEach((element: number) => {
    checkSum += idCounter * element;
    idCounter ++
});



console.log(checkSum);