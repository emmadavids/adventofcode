
with open('treetops.txt', 'r') as f:
    treetops = f.read()

current_path = [] 

forest = treetops.split("\n")

visible_trees = []


# def find_max_tree(max_height, tree):
#     if tree > max_height: 
#         visible_trees.append(forest.index(tree))
#         max_height = tree
#         return max_height

def column_builder(forest):
    return int(forest[idx])

viewing_points = []    


for index, avenue_of_trees in enumerate(forest): #iterates over lines 
    avenue_of_trees = [int (i) for i in avenue_of_trees]
    max_height = avenue_of_trees[0]
    left = 0
    right = 0
    top = 0
    bottom = 0
    adj_tree_l = -1
    adj_tree_r = 1
    adj_tree_t = -1
    adj_tree_b = 1  
    
    # map over
    for idx, tree in enumerate(avenue_of_trees): 
        tree = int(tree)
        verticals = list(map(column_builder, forest)) 
        if ( avenue_of_trees[idx] > max(avenue_of_trees[:idx], default=-1) or

            avenue_of_trees[idx] > max(avenue_of_trees[idx+1:], default=-1) or

            verticals[index] > max(verticals[:index], default=-1) or
            
            verticals[index] > max(verticals[index+1:], default=-1) ):
        
            visible_trees.append(tree)
    
  

        try:
            while avenue_of_trees[idx] >= avenue_of_trees[idx - adj_tree_l]:
                
                left += 1
                adj_tree_l += 1
                print("tree: ", tree, "tree to the right: ", avenue_of_trees[idx - adj_tree_l])
                if avenue_of_trees[idx] == avenue_of_trees[idx - adj_tree_l]:
                    break
            # adj_tree_l += 1
        except IndexError:
            pass
            continue  

    for indx, tree in reversed(list(enumerate(avenue_of_trees))):  
        try:
            while avenue_of_trees[indx] >= avenue_of_trees[indx - adj_tree_r]:
                print("tree: ", tree, "tree to the left: " , avenue_of_trees[indx - adj_tree_r])
                right += 1
                # print("right:", right)
                adj_tree_r += 1  
                if avenue_of_trees[indx] == avenue_of_trees[indx - adj_tree_r]:
                    break
        except IndexError:
            pass
            continue  
          
        
        try:
            while verticals[idx] >= verticals[idx - adj_tree_t]:
             
                top += 1
                # print("right:", right)
                adj_tree_t += 1  
                if verticals[idx] == verticals[idx - adj_tree_t]:
                    break
        except IndexError:
            pass
            continue  
   
    for indx, tree in reversed(list(enumerate(verticals))):  
        try:
            while verticals[indx] >= verticals[indx - adj_tree_b]:
             
                bottom += 1
                # print("right:", right)
                adj_tree_b += 1  
                if verticals[indx] == verticals[indx - adj_tree_b]:
                    break

        except IndexError:
            pass
            continue  
    

    viewing_score = top * bottom * left * right 
    viewing_points.append(viewing_score)
    
