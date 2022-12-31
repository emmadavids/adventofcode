with open('day9/testinput.txt', 'r') as f:
    directions_input = f.read()

directions = directions_input.split("\n")
head_Y = 0 
head_x = 0

tail_Y = 0 
tail_x = 0

knot_positions = [["head index", [0,0]]]

#x horizontal, y vertical
def calculate_tail_position(head_x, head_Y, tail_x_current, tail_Y_current, i):
    diff = [head_x - tail_x_current, head_Y - tail_Y_current]
    if diff == [2, 0]: # different horizontal, same vertical
        tail_x_current += 1
     
    if diff == [-2, 0]:
        tail_x_current -= 1
        
    if diff == [0, 2]: 
        tail_Y_current += 1
      
    if diff == [0, -2]: 
        tail_Y_current -= 1
         
    if diff == [1, -2] or diff == [2, -2] or diff == [2, -1]:  
        tail_x_current += 1
        tail_Y_current -= 1
 
    if diff == [2, 1] or diff == [2, 2] or diff == [1, 2]:
        tail_x_current += 1
        tail_Y_current += 1

    if diff == [-1, 2] or diff == [-2, 2] or diff == [-2, 1]:
        tail_x_current -= 1
        tail_Y_current += 1

    if diff == [-2, -1] or diff == [-2, -2] or diff == [-1, -2]:
        tail_x_current -= 1
        tail_Y_current -= 1
       
    global tail_x
    tail_x = tail_x_current
    global tail_Y
    tail_Y = tail_Y_current   
    knot_positions.append([i, [tail_x, tail_Y]])

#call the calculate tail posit funct on the head, to update the knot bebind it, then the knot becomes the head and the subsequent
#knot is the new tail

def build_tail_positions():
    for i in range(9):  #for each movement we must calculate where each of the 9 knots are   
        try:
            #should get the last known position of the head
            head_index = knot_positions[-1:][0][1]
        except IndexError:
            head_index = knot_positions[0][1]
        try:
            tail_index = list(reversed(knot_positions))[9][1]
        except IndexError:
            tail_index = knot_positions[0][1]
        calculate_tail_position(head_index[0], head_index[1], tail_index[0], tail_index[1], i + 1)

def add_head_position():
    heady = ["head index", [head_x, head_Y]]
    knot_positions.append(heady) #indicates the start of a sequence where each subsequent arr is where each knot is sutated


for line in directions: 
    if line[0] == 'R':
        for i in range (int(line[2:])):
            head_x += 1
            add_head_position()
            build_tail_positions()

    elif line[0] == 'L':
        for i in range (int(line[2:])):
            head_x -= 1   
            add_head_position()
            build_tail_positions()
                    
    elif line[0] == 'D':
        for i in range ((int(line[2:]))):
            head_Y += 1
            add_head_position()
            build_tail_positions()                    
               
    elif line[0] == 'U':
        for i in range (int(line[2:])):
            head_Y -= 1  
            add_head_position()
            build_tail_positions()
    
sitions = set()
for i in knot_positions:
    if i[0] == 9:
        sitions.add(tuple(i[1]))     
print(sitions)
 
print(len(sitions))

# wrong: (2, -3), (1, -4)
# (2, -5), (3, -5, (4, -5) and so forth, too many, should start at 3, - 5

# 2, -2), (2, -2), (2, -3) should be (2, -1) instead of (2, -3)
