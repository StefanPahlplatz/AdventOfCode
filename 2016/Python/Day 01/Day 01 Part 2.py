xpos = 0
ypos = 0
d = 0   # North, East, South, West
gotFirstPosTwice = False
prevPoints = []

# Read the file
with open("day1.txt") as f:
    content = f.read().split(", ")

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
    for j in range(0, length):
        if not gotFirstPosTwice:
            for k in range(0, len(prevPoints)):
                if (xpos, ypos) == prevPoints[k]:
                    print("Answer part 2: {0}".format(abs(xpos + ypos)))
                    gotFirstPosTwice = True
            prevPoints.append((xpos, ypos))

        if d == 0:
            ypos += 1
        elif d == 1:
            xpos += 1
        elif d == 2:
            ypos -= 1
        elif d == 3:
            xpos -= 1

print("Answer part 1: {0}".format(abs(xpos + ypos)))
