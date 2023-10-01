
from collections import defaultdict

with open('cli_input.txt', 'r') as f:
    cli_input = f.read()

filepath = [] #add or take way 
directories = defaultdict(int)
lines = cli_input.split("\n")
directory_name = ""
is_new_directory = False
for line in lines:
    if line[:3] == "dir":
        "fired"
        directories[line[3:]] = ""

    if is_new_directory == True:
        directories[directory_name] = line 

    if line[:4] == "$ cd": 
      
        directory_name = line[5:]
        print("directory name", directory_name)
        is_new_directory = True

    if line[:7] != "$ cd ..":
            is_new_directory = False
                

print(directories)

#build is_subdirectory function which creates running total and checks to see if directory is a subdirectory of another 