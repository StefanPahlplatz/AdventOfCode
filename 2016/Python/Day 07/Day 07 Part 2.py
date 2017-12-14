import re


def find_abas(x):
    matches = []
    for j in range(0, len(x) - 2):
        if x[j] == x[j + 2] and x[j] != x[j + 1]:
            matches.append(x[j + 1] + x[j] + x[j + 1])
    return matches

# Get all lines from the file split by [ and ]
lines = [re.split("\[([^\]]+)\]", line) for line in open("day7.txt")]
total_valid = 0
for line in lines:
    valid = False
    abas = []
    # Loop all even parts
    for i in range(0, len(line)):
        if i % 2 == 0:
            abas.extend(find_abas(line[i]))
    for k in range(0, len(line)):
        if k % 2 != 0:
            if any(aba in line[k] for aba in abas):
                valid = True
    if valid:
        total_valid += 1
print("Total valid:", total_valid)
