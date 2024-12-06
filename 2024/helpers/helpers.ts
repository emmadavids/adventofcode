import * as fs from 'fs';

function readInput(filePath: string): string {
    return fs.readFileSync(filePath, 'utf-8').trim();
}

function parseInput(filePath: string, splitFn: (input: string) => any): any {
    const input = readInput(filePath);
    return splitFn(input);
}


function splitByComma(input: string): string[] {
    return input.split(',');
}

function splitBySpace(input: string): string[] {
    return input.split(/\s+/);
}

function splitIntoLines(input: string): string[] {
    return input.split('\n');
}

function splitLinesToNumbers(input: string): number[][] {
    return splitIntoLines(input).map(line => line.split(/\s+/).map(Number));
}

function splitToPairs(input: string): [number, number][] {
    return splitIntoLines(input).map(line => {
        const [a, b] = line.split(/\s+/).map(Number);
        return [a, b];
        });
}
