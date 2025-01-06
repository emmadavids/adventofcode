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
        // console.log(fileSystem)
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
}

function partTwo(fileSystem:any): any {
    const bulkFiles = [];
    let currentFile: string | any[] = [];

    for (let i = 0; i < fileSystem.length; i++)
    {
        if (fileSystem[i] === '.')
        {
            if (currentFile.length > 0)
            {
                bulkFiles.push({
                    value: currentFile[0],
                    length: currentFile[0].length,
                    index: i - currentFile.length
                });
                currentFile = []
            }
        } else {
            if (currentFile.length === 0 ||
                fileSystem[i] === currentFile[0])
                {
                    currentFile.push(fileSystem[i]);
                }
            
            if (currentFile.length > 0)
            {
                if (currentFile.length > 0)
                {
                    bulkFiles.push(
                        {
                            value: currentFile[0],
                            length: currentFile.length,
                            index: i - currentFile.length
                        }
                    )
                }
                currentFile = [fileSystem[i]];
            }
        }
    }
    if (currentFile.length > 0) {
        bulkFiles.push({
            value: currentFile[0],
            length: currentFile.length,
            index: fileSystem.length - currentFile.length
        });
    }
    bulkFiles.reverse();

    for (const bulkFile of bulkFiles)
    {
        let spaceLength = 0;
        let spaceStart = -1;
        for (let i = 0; i < bulkFile.index; i++)
        {
            if (fileSystem[i] === '.')
            {
                if (spaceLength === 0) spaceStart = i;
                spaceLength++;
                if (spaceLength === bulkFile.length)
                {
                    for (let j = 0; bulkFile.length; j++)
                    {
                        fileSystem[spaceStart + j] = bulkFile.value;
                        fileSystem[bulkFile.index +j] = '.';
                    }
                    break;
                }
                } else {
                    spaceLength = 0;
                    spaceLength = -1;
                }
            }
        }
        return fileSystem
    };


const fileSystem = parseInput();
// moveFilesIntoSpaces(fileSystem);
//107719471277 too low
//8380971534089 also wrong
//8665304481511
//6431472344710
let checkSum = 0;

const files = partTwo(fileSystem);

files.forEach((element: any, index: number) => {    
    if (element !== ".")
    {
        checkSum += index * element;     
    }
});
console.log(checkSum);

//00992111777.44.333....5555.6666.....8888..