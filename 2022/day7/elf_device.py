from collections import defaultdict
with open('cli_input.txt', 'r') as f:
    cli_input = f.read()

current_path = [] 
directories = defaultdict(int)
lines = cli_input.split("\n")

for line in lines:
    if line[:4] == "$ cd": 
        directory_name = line[5:]
        if directory_name.startswith(".."):
            current_path.pop()
        else:
            current_path.append(directory_name)
            # if not directories["/".join(current_path)]:
            #     directories["/".join(current_path)] = 0
    elif(line.startswith('$ ls')):
        continue        
    else:
        splits = line.split(" ")
        size = splits[0]
        if size.isnumeric():
            directory_path = current_path.copy()
            for i in range(len(directory_name)):
                directories['/'.join(directory_path[:i+1])] += int(size)
            
print(directories)
                

count = 0        
for key, value in directories.items():
    print(value)
    if(value <= 100000):
        count += value

print(count)