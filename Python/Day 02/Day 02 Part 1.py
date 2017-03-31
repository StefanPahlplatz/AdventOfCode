lock = [['0', '0', '1', '0', '0'],
        ['0', '2', '3', '4', '0'],
        ['5', '6', '7', '8', '9'],
        ['0', 'A', 'B', 'C', '0'],
        ['0', '0', 'D', '0', '0']]

x = 0
y = 2

# Read the file
with open("day2.txt") as f:
    file = f.read().splitlines()

for i in range(0, len(file)):
    for j in range(0, len(file[i])):
        if file[i][j] == "U":
            y -= 1
            if y < 0:
                y = 0
            elif lock[y][x] == '0':
                y += 1
        elif file[i][j] == "D":
            y += 1
            if y > 4:
                y = 4
            elif lock[y][x] == '0':
                y -= 1
        elif file[i][j] == "L":
            x -= 1
            if x < 0:
                x = 0
            elif lock[y][x] == '0':
                x += 1
        else:
            x += 1
            if x > 4:
                x = 4
            elif lock[y][x] == '0':
                x -= 1
    print(lock[y][x], end="")

