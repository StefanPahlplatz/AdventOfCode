class Line(object):
    def __init__(self, _x, _y, _z):
        self.pos = []
        self.pos.append(_x)
        self.pos.append(_y)
        self.pos.append(_z)

    def get(self, p):
        return self.pos[p]


possible = 0
i = 0
lines = []

# Read the file
with open("day3.txt") as f:
    file = f.read().split()

while i < len(file):
    x = int(file[i])
    y = int(file[i + 1])
    z = int(file[i + 2])
    i += 3
    lines.append(Line(x, y, z))

j = 0
while j < len(lines):
    for k in range(0, 3):
        a = Line.get(lines[j + 0], k)
        b = Line.get(lines[j + 1], k)
        c = Line.get(lines[j + 2], k)

        if a + b > c and b + c > a and a + c > b:
            possible += 1
    j += 3

print(possible)
