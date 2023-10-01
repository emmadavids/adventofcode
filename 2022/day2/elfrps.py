with open('strategyguide.txt', 'r') as f:
    strategy_guide = f.read()
#process the data into individual lists 

#Your total score is the sum of your scores for each round. 
# The score for a single round is the score for the shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors)
#  plus the score for the outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won). 


all_plays = []
myarray = strategy_guide.split("\n")
points = 0
for line in myarray:
    if line[0] == 'A' and line[2] == 'X': #rock and rock 1 + 3 draw
        print("fired")
        points += 4
    elif line[0] == 'A' and line[2] == 'Y': #rock and paper 1 + 6 win
        points += 8
    elif line[0] == 'A' and line[2] == 'Z': #rock and scissors 0 + 3 lose
        points += 3       
    elif line[0] == 'B' and line[2] == 'X': #paper and rock 1 + 0 lose
        points += 1
    elif line[0] == 'B' and line[2] == 'Y': #paper and paper 2 + 3 draw
        points += 5
    elif line[0] == 'B' and line[2] == 'Z': #paper and scissors 3 + 6 win
        points += 9     
    elif line[0] == 'C' and line[2] == 'X': #scissors and rock 1 + 6 
        points += 7           
    elif line[0] == 'C' and line[2] == 'Y': #scissors and paper 2 + 0
        points += 2     
    elif line[0] == 'C' and line[2] == 'Z': #scissors and scissors 3 + 3 draw
        points += 6          
    print(line, points)    

more_points = 0 
for line in myarray:
    if line[0] == 'A': 
        if line[2] == 'X':
            more_points += 3 #0 + 3
        if line[2] == 'Y': # 3 + 1
            more_points += 4
        if line[2] == 'Z':
            more_points += 8 #2 + 6
    if line[0] == 'B':
        if line[2] == 'X':
            more_points += 1 
        if line[2] == 'Y':
            more_points += 5 #2 + 3
        if line[2] == 'Z':
            more_points += 9 
    if line[0] == 'C':
        if line[2] == 'X':
            more_points += 2 
        if line[2] == 'Y':
            more_points += 6
        if line[2] == 'Z':
            more_points += 7 
    print("more points", more_points)   


# In the first round, your opponent will choose Rock (A), and you need the round to end in a draw (Y), so you also choose Rock. This gives you a score of 1 + 3 = 4.
# In the second round, your opponent will choose Paper (B), and you choose Rock so you lose (X) with a score of 1 + 0 = 1.
# In the third round, you will defeat your opponent's Scissors with Rock for a score of 1 + 6 = 7.
