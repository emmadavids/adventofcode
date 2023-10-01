with open('test_input.txt') as f:
    packet_data = [line.strip() for line in f if line.strip()]

correctly_ordered = 0
right_lists = []
left_lists = []
right = 0
left = 0

for i in range(0, len(packet_data), 2):
    print(f"Comparing {packet_data[i]} and {packet_data[i+1]}")

    for idx, elem in enumerate(packet_data[i]):
        # if packet_data[i][left][0] == 
        if elem == "[":
            left += 1 
        # if elem == "]":
        #     print(packet_data[i], "closed bracket at", idx)
    
    for idx, elem in enumerate(packet_data[i+1]):
        if elem == "[":
            right += 1
        # if elem == "]":
        #     print(packet_data[i], "closed bracket at", idx)
    print("number of lists in left:", left -1)   
    print("number of lists in right:", right -1) 
    left = 0
    right = 0    

    # [5,6,7]]]],8,9] vs [5,6,0]]]],8,9]
#   - Compare 1 vs 1
#   - Compare [2,[3,[4,[5,6,7]]]] vs [2,[3,[4,[5,6,0]]]]
#     - Compare 2 vs 2
#     - Compare [3,[4,[5,6,7]]] vs [3,[4,[5,6,0]]]
#       - Compare 3 vs 3
#       - Compare [4,[5,6,7]] vs [4,[5,6,0]]
#         - Compare 4 vs 4
#         - Compare [6,7] vs [6,0]
#           - Compare 5 vs 5
#           - Compare 6 vs 6
#           - Compare 7 vs 0
#if equal to then pop.left