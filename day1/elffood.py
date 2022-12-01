
with open('elfcalories.txt', 'r') as f:
    elf_calories_share = f.read()
#process the data into individual lists 

all_elf_calories = []
myarray = elf_calories_share.split("\n\n")
for line in myarray:
 
    line = line.replace('\n', ',')
    line = [int(s) for s in line.split(',')]
    all_elf_calories.append(line)


def find_largest_calories_load(arr):
    largest = 0 
    for i in arr:
        total = sum(i)
        if total > largest:
            largest = total
    print("largest: " + str(largest))        
       

find_largest_calories_load(all_elf_calories)


new_arr = []
def sort_by_calories(arr):
    for i in arr:
        total = sum(i)
        new_arr.append(total)
    new_arr.sort(reverse=True)
    summy = new_arr[0] + new_arr[1] + new_arr[2]
    print("sum: ", summy)


sort_by_calories(all_elf_calories)