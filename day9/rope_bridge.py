
with open('testinput.txt', 'r') as f:
    directions_input = f.read()

directions = directions_input.split("\n")
head_Y = 0 
head_x = 0

tail_Y = 0 
tail_x = 0

tail_positions = [[0,0]]

# If the head is ever two steps directly up, down, left, or right from the tail, the tail must also move one step in that direction so it remains close enough:

# def is_2steps_ahead():        
#     if ( vertical_axis_head - vertical_axis_tail > 1 #checks if tail is more than one space below
#         or vertical_axis_tail - vertical_axis_head > 1 #checks if tail is more than one above
#         or horizontal_axis_head - horizontal_axis_tail > 1 #checks if tail is more than one space to the right
#         or horizontal_axis_tail - horizontal_axis_head > 1 ): #checks if tail is more than one space to the left
#         return True


#compare head XY and tail XY simultaneously

#x horizontal, y vertical
def calculate_tail_position(head_x, head_Y, tail_x_current, tail_Y_current):
    diff = [head_x - tail_x_current, head_Y - tail_Y_current]
    if diff == [2, 0]: # different horizontal, same vertical
        tail_x_current += 1
        # tail_coordinates.append([tail_x + 1, tail_Y])   
    if diff == [-2, 0]:
        tail_x_current -= 1
        # tail_coordinates.append([tail_x - 1, tail_Y])   
    if diff == [0, 2]: 
        tail_Y_current += 1
        # tail_coordinates.append([tail_x, tail_Y + 1])     
    if diff == [0, -2]: 
        tail_Y_current -= 1
        # tail_coordinates.append([tail_x, tail_Y - 1])    
    if diff == [1, -2] or diff == [2, -2] or diff == [2, -1]:  
        tail_x_current += 1
        tail_Y_current -= 1
        # tail_coordinates.append([tail_x + 1, tail_Y - 1])  
    if diff == [2, 1] or diff == [2, 2] or diff == [1, 2]:
        tail_x_current += 1
        tail_Y_current += 1
        # tail_coordinates.append([tail_x + 1, tail_Y + 1])
    if diff == [-1, 2] or diff == [-2, 2] or diff == [-2, 1]:
        tail_x_current -= 1
        tail_Y_current += 1
        # tail_coordinates.append([tail_x - 1, tail_Y + 1])
    if diff == [-2, -1] or diff == [-2, -2] or diff == [-1, -2]:
        tail_x_current -=1
        tail_Y_current -= 1
        # tail_coordinates.append([tail_x -1, tail_Y -1])
    global tail_x
    tail_x = tail_x_current
    global tail_Y
    tail_Y = tail_Y_current   
    tail_positions.append([tail_x, tail_Y])



for line in directions: 
    if line[0] == 'R':
        for i in range (int(line[2:])):
            head_x += 1
            calculate_tail_position(head_x, head_Y, tail_x, tail_Y)
    elif line[0] == 'L':
        for i in range (int(line[2:])):
            head_x-= 1   
            calculate_tail_position(head_x, head_Y, tail_x, tail_Y)
    
    elif line[0] == 'D':
        for i in range ((int(line[2:]))):
            head_Y += 1
            calculate_tail_position(head_x, head_Y, tail_x, tail_Y)
    elif line[0] == 'U':
        for i in range (int(line[2:])):
            head_Y -= 1  
            calculate_tail_position(head_x, head_Y, tail_x, tail_Y)              
 



# for line in directions: 
#     if line[0] == 'R':
#         for i in range (int(line[2:])):
#             horizontal_axis_head += 1
#             if horizontal_axis_head - horizontal_axis_tail > 1: #if the head is more than 2 steps to the right of the tail
#                 horizontal_axis_tail += 1
#             if is_same_column() == False: #if tail/head not in same column/row
                   
#                 if vertical_axis_head - vertical_axis_tail > 1: #if the head is above the tail move it to be in line
#                     vertical_axis_tail += 1
#                 else:
#                     vertical_axis_tail -= 1  

#             tail_move = [horizontal_axis_tail, vertical_axis_tail]
#             tail_positions.append(tail_move)



#     elif line[0] == 'L':
#         for i in range (int(line[2:])):
#             horizontal_axis_head -= 1
#             if horizontal_axis_tail - horizontal_axis_head > 1: #if the tail is more than 2 steps to the left of the head
#                 horizontal_axis_tail -= 1

#             if is_same_column() == False:
#                 if vertical_axis_head - vertical_axis_tail > 1: #bring it into the same column
#                     vertical_axis_tail += 1
#                 else:
#                     vertical_axis_tail -= 1  
#             tail_move = [horizontal_axis_tail, vertical_axis_tail]
#             tail_positions.append(tail_move)

#     elif line[0] == 'U':
#         for i in range (int(line[2:])):
#             vertical_axis_head -= 1
#             if vertical_axis_head - vertical_axis_tail > 1: #if the head is more than 2 steps above the tail
#                 vertical_axis_tail += 1
#             elif vertical_axis_head - vertical_axis_tail < -1:
#                 vertical_axis_tail -= 1
#             if not is_same_column():
#                 if horizontal_axis_head - horizontal_axis_tail < -1:
#                     horizontal_axis_tail -= 1
#                 elif horizontal_axis_head - horizontal_axis_tail > 1:
#                     horizontal_axis_tail += 1  
 
#             tail_move = [horizontal_axis_tail, vertical_axis_tail]
#             tail_positions.append(tail_move)    

# # U 4 ->  [3, 0], [4, -1], [4, -2], [4, -3], 

#     elif line[0] == 'D':
#         for i in range ((int(line[2:]))):

#             vertical_axis_head += 1
#             if vertical_axis_tail - vertical_axis_head > 1: #if the head is more than 2 steps below the tail
#                 vertical_axis_tail += 1
#             if not is_same_column():
#                 if horizontal_axis_head - horizontal_axis_tail > 1:
#                     horizontal_axis_tail -= 1
#                 else:
#                     horizontal_axis_tail += 1     

#             tail_move = [horizontal_axis_tail, vertical_axis_tail]
#             tail_positions.append(tail_move)   

            
set_of_positions = set(tuple(element) for element in tail_positions)

print(len(set_of_positions))

# R 4 ->  [[0, 0], [0, 0], [1, 0], [2, 0], [3, 0], 
# U 4 ->  [3, 0], [4, -1], [4, -2], [4, -3], 

# L 3 ->  [4, -3], [3, -4], [2, -4],