with open('day10/clock_circuit.txt', 'r') as f:
    clock_circuit_input = f.read()


clock_circuit = clock_circuit_input.split("\n")
cycles = 0
sprite_position = 1
signal_strengths = []
crt_output = [[],[],[],[],[],[]]

#each cycle draws a pixel
#if it is in line with sprite
#array for each new line, push to overall array

def draw_pixel():
    if (cycles == sprite_position
        or cycles == sprite_position + 1
        or cycles == sprite_position - 1
        or cycles % 40 == sprite_position
        or cycles % 40 == sprite_position + 1
        or cycles % 40 == sprite_position - 1
        ):
        return '#'
    else:
        return '.'     

def check_line():
    pixel = draw_pixel()
    if cycles < 40:
        crt_output[0].append(pixel)
    elif cycles < 80:   
        crt_output[1].append(pixel) 
    elif cycles < 120:   
        crt_output[2].append(pixel)   
    elif cycles < 160:   
        crt_output[3].append(pixel)
    elif cycles < 200:   
        crt_output[4].append(pixel)          
    elif cycles < 240:   
        crt_output[5].append(pixel)          

# def check_signal_strength():
#     if ( cycles == 20 
#         or cycles == 60
#         or cycles == 100
#         or cycles == 140
#         or cycles == 180
#         or cycles == 220 ):
#         signal_strengths.append(cycles * sprite_position)

  
for line in clock_circuit:

    if line[0:4] == "noop":
        check_line()
        cycles += 1
        
  

    if line[0:4] == "addx":
        for i in range(2):
            check_line()
            cycles += 1
        sprite_position += int(line[4:])    
  
# print(signal_strengths)
# print(sum(signal_strengths))        


li2 = []
for sublist in crt_output:
    li2.extend(sublist)

print(' '.join(li2))