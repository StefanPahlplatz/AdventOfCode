import re


def check_abba(x):
    return any(a == d and b == c and a != b for a, b, c, d in zip(x, x[1:], x[2:], x[3:]))

# Get all lines from the file split by [ and ]
lines = [re.split("\[([^\]]+)\]", line) for line in open("day7.txt")]
total_valid = 0
for line in lines:
    valid = False
    for i in range(0, len(line)):
        if i % 2 == 0:
            if check_abba(line[i]):
                valid = True
        else:
            if check_abba(line[i]):
                valid = False
                break
    if valid:
        total_valid += 1
print("Total valid:", total_valid)
