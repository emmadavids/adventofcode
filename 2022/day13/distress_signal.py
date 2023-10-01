import json

with open('packet_data.txt') as f:
    packet_data = [json.loads(line.strip()) for line in f if line.strip()]

correctly_ordered_packets = 0
indices = []


def compare(left_side, right_side):

    if not isinstance(left_side, list): 
        left_side = list(left_side)
    if not isinstance(right_side, list):    
        right_side = list(right_side)

    if len(left_side) == 0:
        return True
    if len(right_side) == 0:
        return False

    print("left_side", left_side, ", right side: ", right_side)
    first_left = left_side[0]
    first_right = right_side[0]

    if isinstance(first_left, list) and isinstance(first_right, int):
        first_right = [first_right]
    elif isinstance(first_left, int) and isinstance(first_right, list):
        first_left = [first_left]

    if isinstance(first_left, list) and isinstance(first_right, list):
        result = compare(first_left, first_right)
        if result is not None:
            return result
        
        return compare(left_side[1:, right_side[1:]])

    if first_right < first_left:
        return False
    if first_left < first_right:
        return True
    print("lefty righty", left_side[1:], right_side[1:])
    return compare(left_side[1:], right_side[1:])

for i in range(0, len(packet_data), 2):
    print(f"Comparing {packet_data[i]} and {packet_data[i+1]}")
    if compare(packet_data[i], packet_data[i+1]):
        correctly_ordered_packets += 1
        indices.append(int(i/2+1))
        # print("i",i)


print(sum(indices))
