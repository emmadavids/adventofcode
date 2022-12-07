import re

with open('crates.txt', 'r') as f:
    crates_input = f.read()

crates_lines = crates_input.split("\n")
crate_arrays = []

current_line = ""
index = 0

for line in crates_lines[:9]:
    unprocessed_crate_stack = []
    for char in line:
        unprocessed_crate_stack.append(char)
        crate_arrays.append(unprocessed_crate_stack) 
    # for char in line:
    #         crate_arrays.append([])
    #     else:
    #     # = 
    #         break

print("unp: ", unprocessed_crate_stack)
crate_stacks = [list(tup) for tup in zip(*unprocessed_crate_stack)]

print("proc ", crate_stacks)
# def place_arr():
#     f


# for line in crates_lines[:9]:
#     if line[1] != " ":
#         arr1.append(line[1])
#     if line[5] != " ":    
#         arr2.append(line[5])
#     if line[9] != " ":    
#         arr3.append(line[9])
#     if line[13] != " ":    
#         arr4.append(line[13])
#     if line[17] != " ":    
#         arr5.append(line[17])
#     if line[21] != " ":    
#         arr6.append(line[21])
#     if line[25] != " ":    
#         arr7.append(line[25])
#     if line[29] != " ":    
#         arr8.append(line[29])
#     if line[33] != " ":    
#         arr9.append(line[33])


# nums_arr = []
# for line in crates_lines[10:]:
#     nums = [int(s) for s in re.findall(r'\b\d+\b', line)]
#     nums_arr.append(nums)


# move 8 from 3 to 2
# moved_from = 0
# moved_to = 0 
# for arrs in nums_arr:
#     for stack in crate_arrays:
#         if int(stack[len(stack) - 1]) == arrs[1]:
#             moved_from = stack
#             print("moved from", moved_from)
#         if int(stack[len(stack) - 1]) == arrs[2]:
#             moved_to = stack
#             print("moved to", moved_to)
#         moved_to.insert(stack[len(stack) - 1], moved_from[:arrs[0]])    

# print(crate_arrays)
            