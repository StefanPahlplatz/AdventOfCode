possible = 0
i = 0

# Read the file
with open("day3.txt") as f:
    file = f.read().split()

while i < len(file):
    x = int(file[i])
    y = int(file[i + 1])
    z = int(file[i + 2])
    if (x + y > z) and (x + z > y) and (z + y > x):
        possible += 1
    i += 3
print(possible)
