import re

with open('crates.txt', 'r') as f:
    crates_input = f.read()

crates_lines = crates_input.split("\n")

current_line = ""

count = len(crates_lines[:9]) + 1
print("count: ", count)

index = 1
crate_stacks = []
while 1 < count:
    single_stack = [] 
    count -= 1
    for line in crates_lines[:8]:
        if line[index] != " ":
            single_stack.append(line[index])
    index += 4        
    crate_stacks.append(single_stack)


nums_arr = []
for line in crates_lines[10:]:
    nums = [int(s) for s in re.findall(r'\b\d+\b', line)]
    new_num = [nums[0], nums[1] - 1, nums[2] - 1]
    nums_arr.append(new_num)


moved_from = []
moved_to = []
counter = len(crate_stacks)
for num in nums_arr:
    moved_from = crate_stacks[num[1]][:num[0]]
    del crate_stacks[num[1]][:num[0]]
    for i in reversed(moved_from):
        crate_stacks[num[2]].insert(0, i)

top_boxes = []
for i in crate_stacks:
    top_boxes.append(i[0])

print("top boxes", top_boxes)    


