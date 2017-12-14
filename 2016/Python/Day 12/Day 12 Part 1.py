import re

registers = dict.fromkeys(['a', 'b', 'c', 'd'], 0)

with open("day12.txt") as f:
    file = f.readlines()
    i = 0
    while True:
        if i >= len(file):
            print("Answer part 1:", registers['a'])
            break
        matches = re.findall("[^=\s]*", file[i])
        if "cpy" in file[i]:
            try:
                x = int(matches[2])
            except ValueError:
                x = registers[matches[2]]
            y = matches[4]
            registers[y] = x

        elif "inc" in file[i]:
            registers[matches[2]] += 1

        elif "dec" in file[i]:
            registers[matches[2]] -= 1

        else:
            try:
                x = int(matches[2])
            except ValueError:
                x = registers[matches[2]]

            if x != 0:
                i -= 1
                y = int(matches[4])
                i += y
        i += 1
