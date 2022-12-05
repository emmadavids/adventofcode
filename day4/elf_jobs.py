import unittest

with open('assignments.txt', 'r') as f:
    assignments = f.read()

elf_assignments = assignments.split("\n")  

processed_elf_arr = []

#process the input into usable format
for line in elf_assignments:
    each_elf_assignments = line.split(",")
    first_elf_assignments = [int(x) for x in each_elf_assignments[0].split("-")]
    second_elf_assignments = [int(x) for x in each_elf_assignments[1].split("-")]
    elf_pair_arr = [first_elf_assignments, second_elf_assignments]
    processed_elf_arr.append(elf_pair_arr)


fully_contained = []  


def check_fully_contains():
    for arr in processed_elf_arr:
        if arr[0][0] <= arr[1][0] and arr[0][1] >= arr[1][1]:
            fully_contained.append(arr)
        elif arr[1][0] <= arr[0][0] and arr[1][1] >= arr[0][1]:
            fully_contained.append(arr)

check_fully_contains()

count = 0
for i in fully_contained:
    count += 1

# don't
# 2-4,6-8 
# 2-3,4-5 

2 < 6 
4 < 6


# do
# 5-7,7-9, 
# 2-8,3-7, 
# 6-6,4-6,  
# 2-6,4-8
 

print(count)
overlapping_duties = []
dont_overlap = []
def check_overlap():
    for arr in processed_elf_arr:
        print("arrrr: ", arr)
        if arr[0][0] < arr[1][0] and arr[0][1] < arr[1][0]: #if duties are both lower 
            dont_overlap.append(arr)
        elif arr[0][0] > arr[1][1] and arr[0][1] > arr[1][1]: #if duties are both higher
            dont_overlap.append(arr)
        else:
            overlapping_duties.append(arr)

check_overlap()
counter = 0
for i in overlapping_duties:
    counter += 1

print(counter)    

