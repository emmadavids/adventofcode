from collections import deque

with open('elevation_map.txt', 'r') as f:
    elevation_map = f.read().splitlines()

alphabet_values = {'S':1, 'a':1, 'b':2, 'c':3, 'd':4, 'e':5, 'f':6, 'g':7, 'h':8, 'i':9,
                'j':10, 'k':11, 'l':12, 'm':13, 'n':14, 'o':15, 'p':16, 'q':17, 'r':18,
                's':19, 't':20, 'u':21, 'v':22, 'w':23, 'x':24, 'y':25, 'z':26, 'E': 27}

elevation_map = [list(line) for line in elevation_map]

neighbouring_coordinates = [(- 1, 0),(0, -1),(0, 1),(1, 0)]



start = None
end = None 

lots_of_a_squares = []

for y, line in enumerate(elevation_map): 
    for x, char in enumerate(line): 
        if char == "a":
            lots_of_a_squares.append((y,x))
        if char == "E":
            end = (y, x)
            print(y, x)
            break
        if char == "S":
            start = (y, x)
            print(y, x)

def hill_bfs(elevation_map, start, end):
    visited = set() 
    queue = deque([(start, 0)])
    parents = {}

    while queue:
        (y, x), steps = queue.popleft()
        current_step_height = alphabet_values.get(elevation_map[y][x][0])

        if (y, x) == end:
            path = [(y, x)]
            while (y, x) != start:
                (y, x) = parents[(y, x)]
                path.append((y, x))
            path.reverse()
            return steps, path

        if (y, x) in visited:
            continue
        visited.add((y, x))
        for p, q in neighbouring_coordinates:
            new_y, new_x = y + p, x + q
            if (
                0 <= new_y < len(elevation_map)
                and 0 <= new_x < len(elevation_map[0])
                and (new_y, new_x) not in visited
            ):
                neighbouring_step_height = alphabet_values.get(elevation_map[new_y][new_x])
                if neighbouring_step_height is not None and (
                    neighbouring_step_height <= current_step_height + 1
                ):
                    queue.append(((new_y, new_x), steps + 1))
                    parents[(new_y, new_x)] = (y, x)

    return None, None

steps, path = hill_bfs(elevation_map, start, end)

steps, path = hill_bfs(elevation_map, start, end)
print("all the As", len(lots_of_a_squares))

steppity = []
for a in lots_of_a_squares:
    steps, path = hill_bfs(elevation_map, a, end)
    if steps is not None:
        steppity.append(steps)

print("lowest: ", min(steppity))

