
with open('treetops.txt', 'r') as f:
    treetops = f.read()

forest = treetops.split("\n")

visible_trees = []


def column_builder(forest):
    return int(forest[idx])

viewing_points = []    



for index, avenue_of_trees in enumerate(forest): #iterates over lines 
    avenue_of_trees = [int (i) for i in avenue_of_trees]
    max_height = avenue_of_trees[0]

    for idx, tree in enumerate(avenue_of_trees): 
 
        tree = int(tree)
        verticals = list(map(column_builder, forest)) 

        left = list(reversed(avenue_of_trees[:idx]))
        right = avenue_of_trees[idx+1:]
        top = list(reversed(verticals[:index]))
        bottom = verticals[index+1:]

        if ( avenue_of_trees[idx] > max(left, default=-1) or

            avenue_of_trees[idx] > max(right, default=-1) or

            verticals[index] > max(top, default=-1) or
            
            verticals[index] > max(bottom, default=-1) ):
        
            visible_trees.append(tree)
    
        left_score = 0 
        right_score = 0 
        top_score = 0
        bottom_score = 0
    
        higher = next(filter(lambda tree: tree >= avenue_of_trees[idx], left), None)

        if higher == None:
            left_score = len(left)
        else:
            left_score = left.index(higher) + 1
            #returns the index of the first tree that is bigger or same size as the iterating tree
        print("tree:", tree, ", left score: ", left_score )
        higher = next(filter(lambda tree: tree >= avenue_of_trees[idx], right), None)
        if higher == None:
            right_score = len(right) 
        else:
          
            right_score = right.index(higher) + 1
            
        higher = next(filter(lambda tree: tree >= avenue_of_trees[idx], bottom), None)
        if higher == None:
            bottom_score = len(bottom)
        else:
          
            bottom_score = bottom.index(higher) + 1    

        higher = next(filter(lambda tree: tree >= avenue_of_trees[idx], top), None)

        if higher == None:
            top_score = len(top) 
        else:
          
            top_score = top.index(higher) + 1    

        total_score = top_score * bottom_score * left_score * right_score
        viewing_points.append(total_score)


print("max viewing score: ", max(viewing_points))

counter = 0
for i in visible_trees:
    counter+=1

