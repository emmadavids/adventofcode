

# remove 'day 8' text if running from Terminal; it is required for the debugger 
with open('treetops.txt', 'r') as f:
    treetops = f.read()

forest = treetops.split("\n")

visible_trees = []


def column_builder(forest):
    return int(forest[idx])

viewing_points = []    

# def find_first_bigger_tree(dimension, tree):
#         for i in dimension:
#             print("i", i)
#             print("tree", tree)
#             if i >= tree: break
#                 print("dimension index:", dimension.index(i))
#                 return dimension.index(i)

for index, avenue_of_trees in enumerate(forest): #iterates over lines 
    avenue_of_trees = [int (i) for i in avenue_of_trees]
    max_height = avenue_of_trees[0]

    for idx, tree in enumerate(avenue_of_trees): 
        # left = 0
        # right = 0
        # top = 0
        # bottom = 0
        # adj_tree_l = 1
        # adj_tree_r = 1
        # adj_tree_t = -1
        # adj_tree_b = 1  
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
        # print("tree:", tree, "right score:", right_score)
        # for index, elem in enumerate(left):
        #     if elem >= avenue_of_trees[idx]:
        #         left_score = idx - index
            # raise ValueError("Nothing Found")

        # print("left score:", left_score)
        # lefto = find_first_bigger_tree(left, avenue_of_trees[idx])
  

        # print("tree: ", tree, " left score:", left_score) 

        # np.argwhere(np.array(searchlist)>x)[0][0]
    #use slice/substring in ur 2d loop and return index of first occurrence of a tree that is >= than iterating tree

    #     try:
    #         while avenue_of_trees[idx] >= avenue_of_trees[idx - adj_tree_l]:
    
    #             left += 1
    #             adj_tree_l += 1
    #             if avenue_of_trees[idx] == avenue_of_trees[idx - adj_tree_l]:
    #                 break
    #     except IndexError:
    #         pass
    #         continue  

    # try:
    #     while verticals[idx] > verticals[idx - adj_tree_t]:
    #         print("verticals idx:", verticals[idx])
    #         top += 1
    #         adj_tree_t += 1  
    #         if verticals[idx] == verticals[idx - adj_tree_t]:
    #                 break
    # except IndexError:
    #         pass
    #         continue      

    # for indx, tree in reversed(list(enumerate(avenue_of_trees))):  
    #     try:
    #         while avenue_of_trees[indx] >= avenue_of_trees[indx - adj_tree_r]:
    #             right += 1
    #             adj_tree_r += 1  
    #             if avenue_of_trees[indx] == avenue_of_trees[indx - adj_tree_r]:
    #                 break
    #     except IndexError:
    #         pass
    #         continue  
          
        
   
   
    # for indx, tree in reversed(list(enumerate(verticals))):  
    #     try:
    #         while verticals[indx] >= verticals[indx - adj_tree_b]:
    #             print(verticals[indx])
    #             bottom += 1
    #             adj_tree_b += 1  
    #             if verticals[indx] == verticals[indx - adj_tree_b]:
    #                 break

    #     except IndexError:
    #         pass
    #         continue  
     
    # print(top, bottom, left, right)        
    # viewing_score = top * bottom * left * right 
    # viewing_points.append(viewing_score)
    
# print("max viewing score: ", max(viewing_points))

    # for inx, tree in verticals:          
             
    # print("tree: ", tree, "right:", right, ", left:", left)

        # while avenue_of_trees[idx + 1] < avenue_of_trees[idx:]:    
        #     right += 1
        # while top     

        # if tree == avenue_of_trees[0]: #deal with edge cases
        #     visible_trees.append(tree)
        # if tree > max_height: #visible from left side 
        #     visible_trees.append(forest.index(tree))
        #     max_height = tree
          
    # max_height = avenue_of_trees[len(avenue_of_trees) -1]        
    # for tree in reversed(avenue_of_trees):      
    #     if tree == avenue_of_trees[0]: #deal with edge cases
    #         visible_trees.append(tree)   
    #     if tree > max_height: #visible from right side 

    #         visible_trees.append(forest.index(tree))
    #         max_height = tree
    # max_height = vertical_avenue[0]        
    # for tree in vertical_avenue:
    #     if tree == vertical_avenue[0]: #deal with edge cases
    #         visible_trees.append(tree) 
    #     if tree >= max_height: #visible from top side 
    #         # visible_trees.append(vertical_avenue.index(tree))
    #         max_height = tree   
    # max_height = vertical_avenue[len(vertical_avenue)-1]               
    # for tree in reversed(vertical_avenue):
    #     if tree == vertical_avenue[0]: #deal with edge cases
    #         visible_trees.append(tree) 
    #     if tree >= max_height: #visible from bottom side 
    #         # visible_trees.append(vertical_avenue.index(tree))
    #         max_height = tree                     


counter = 0
for i in visible_trees:
    counter+=1

