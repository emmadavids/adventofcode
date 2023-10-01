import operator
from operator import add, sub, mul

with open('day11/monkeys.txt', 'r') as f:
    monkey_input = f.read()

monkey_shenanigans = monkey_input.split("\n")
all_monkeys = []

class Monkey:
    def __init__(self, id):
        self.id = id
        self.items = []
        self.inspected = 0
        self.operation = []
        self.toss_to = []


    def __str__(self):
        return f"ID: {self.id}, Currently holding: {self.items}, Inspected: {self.inspected}, toss to: {self.toss_to}. operations: {self.operation}"


def find_monkey(id):
    monkey = next((x for x in all_monkeys if x.id == id), None)
    return monkey

monkey_string = "monkey"
monkey_id = 0
for line in monkey_shenanigans: #create monkey classes with unique IDs and starting items 
    if line[0:6] == "Monkey":   
        all_monkeys.append(Monkey(monkey_id))
    if line[2:3] == 'S': 
        selected_monkey = find_monkey(monkey_id)
        starting_items = [int(item) for item in line[18:].split(',')]
        selected_monkey.items = starting_items
        

    if line[2:3] == 'O':
        operator = line[23:24]
        figure = line[25:]
        selected_monkey.operation.append(operator)
        selected_monkey.operation.append(figure)

    if line[2:3] == 'T':
        selected_monkey.operation.append(int(line[21:]))
        monkey_id += 1
    if line[4:8] == 'If t':
        selected_monkey.toss_to.append(line[29:30])  
    if line[4:8] == 'If f': 
        selected_monkey.toss_to.append(line[30:31])


def monkey_maths(item, operations):
    if operations[1] == "old":
        a = item
    else:
        a = int(operations[1])    
    if operations[0] == '+':
        b = item + a
    elif operations[0] == '*':
        b = item * a 
    c = b / 3   
    if int(c) % operations[2] == 0:
        return [int(c), True]
    else:
        return [int(c), False]    
    

counter = 0 
rounds = 0
while rounds <= 1000:
    for monkey in all_monkeys:
        currently_holding = []
        for item in monkey.items:
            currently_holding.append(item)
    
        for i in currently_holding:     
            operation = monkey.operation
            monkey_test = monkey_maths(i, operation)
            if monkey_test[1]:
                monkey_receiver = find_monkey(int(monkey.toss_to[0]))
                monkey_receiver.items.append(monkey_test[0]) 

            else:    
                monkey_receiver = find_monkey(int(monkey.toss_to[1]))
                monkey_receiver.items.append(monkey_test[0]) 
            monkey.inspected += 1
            monkey.items.pop(monkey.items.index(i))
    rounds += 1         
for monkey in all_monkeys:
    print(monkey.inspected)