with open('rucksack_contents.txt', 'r') as f:
    rucksack_contents = f.read()


values = {'a':1, 'b':2, 'c':3, 'd':4, 'e':5, 'f':6, 'g':7, 'h':8, 'i':9,
                'j':10, 'k':11, 'l':12, 'm':13, 'n':14, 'o':15, 'p':16, 'q':17, 'r':18,
                's':19, 't':20, 'u':21, 'v':22, 'w':23, 'x':24, 'y':25, 'z':26, 
                'A':27, 'B':28, 'C':29, 'D':30, 'E':31, 'F':32, 'G':33, 'H':34, 'I':35,
                'J':36, 'K':37, 'L':38, 'M':39, 'N':40, 'O':41, 'P':42, 'Q':43, 'R':44,
                'S':45, 'T':46, 'U':47, 'V':48, 'W':49, 'X':50, 'Y':51, 'Z':52 }

rucksacks = rucksack_contents.split("\n")

items = []
for line in rucksacks:
    first_half, second_half = line[:len(line)//2], line[len(line)//2:]
    array1 = [char for char in first_half]
    array2 = [char for char in second_half]
    doubles = list(set(first_half).intersection(second_half))
    items.append(doubles)
   
print(rucksacks)
new_arr = []
for item in items:
    for i in item:
        new_arr.append(i)

count = 0

for item in sorted(new_arr):
    count += values[item]
print(count)

i = 0

badges = []
while(i < len(rucksacks)):
    chars1 = [char for char in rucksacks[i]]
    chars2 = [char for char in rucksacks[i+1]]
    chars3 = [char for char in rucksacks[i+2]]
    badge = list(set(chars1).intersection(chars2, chars3))
    badges.append(badge)
    i += 3

badge_value = 0
for i in badges:
    badge_value += values[i[0]]
print(badge_value)