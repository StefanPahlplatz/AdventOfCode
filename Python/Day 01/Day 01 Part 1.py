xpos = 0
ypos = 0
d = 0   # North, East, South, West

# Read the file
with open("day1.txt") as f:
    file = f.read()
content = file.split(", ")

# Process
for i in range(0, len(content)):
    if content[i][0] == "L":
        d -= 1
        if d < 0:
            d = 3
    else:
        d += 1
        if d > 3:
            d = 0

    length = int(content[i][1:])
    if d == 0:
        ypos += length
    elif d == 1:
        xpos += length
    elif d == 2:
        ypos -= length
    elif d == 3:
        xpos -= length

print("Answer part 1: {0}".format(abs(xpos + ypos)))
