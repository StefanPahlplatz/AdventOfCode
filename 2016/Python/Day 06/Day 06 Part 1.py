import string

# Read the file
with open("day6.txt") as f:
    file = f.read().split()

# Alphabet as dictonary
d = [dict.fromkeys(string.ascii_lowercase, 0) for k in range(0, len(file[0]))]

# Loop through all lines
for j in range(0, len(file)):
    # Loop trough all characters
    for i in range(0, len(file[0])):
        d[i][file[j][i]] += 1

# Turn the dictonary into an ordered list
for l in range(0, len(d)):
    ordered = sorted(d[l].items(), key=lambda x: x[1], reverse=True)
    print(ordered[0][0], end="")
