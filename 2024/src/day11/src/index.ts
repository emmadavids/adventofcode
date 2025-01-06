const input = "4189 413 82070 61 655813 7478611 0 8"
// const input = "125 17"

function parseInput(): number[] {
const stones = input.split(" ")
    .map(x => Number(x))
    return stones 
}

const stones = parseInput();

const stonesMap = new Map<number, number>();

stones.forEach((item : number) => {
    stonesMap.set(item, 1); 
});

const finalStoneMap = blinkAndMutate(75, stonesMap);

function blinkAndMutate(blinkCount: number, stonesMap : Map<number, number>) : Map<number, number>{
    if (blinkCount == 0) {
        return stonesMap;
    }
    const newStonesMap = new Map<number, number>();
    for (const [stone, count] of stonesMap.entries()) {
        let stoneyString = stone.toString();
        if (stone == 0) {
            newStonesMap.set(1, (newStonesMap.get(1) || 0) + count);
        }
        else if (stoneyString.length % 2 === 0) {
            const half = stoneyString.length / 2;
            const firstStone = Number(stoneyString.slice(0, half));
            const secondStone = Number(stoneyString.slice(half));

            newStonesMap.set(firstStone, (newStonesMap.get(firstStone) || 0) + count);
            newStonesMap.set(secondStone, (newStonesMap.get(secondStone) || 0) + count);
        }
        else {
            const bigStone = stone * 2024;
            newStonesMap.set(bigStone, (newStonesMap.get(bigStone) || 0) + count);
        }
    }
  
    return blinkAndMutate(blinkCount - 1, newStonesMap);
}

let totalSum = 0;

finalStoneMap.forEach((value, key) => {
    totalSum += value;
});
console.log(totalSum)
