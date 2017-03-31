import string
import re

alphabet = list(string.ascii_lowercase)

# Read the file
with open("day4.txt") as f:
    file = f.read().split()

for i in range(0, len(file)):
    # Alphabet as dictonary
    d = dict.fromkeys(string.ascii_lowercase, 0)

    # Get encrypted name
    namefull = file[i]
    namegroup = re.search("([a-z]+-)+", namefull)
    name = namegroup.group(0).replace("-", "")

    # Get the most used characters
    for j in range(0, len(name)):
        d[name[j]] += 1

    # Turn the dictonary into an ordered list
    ordered = sorted(d.items(), key=lambda x: x[1], reverse=True)

    # Get the checksum
    checksum = re.search("(?<=\[).*(?=\])", namefull).group(0)

    # Check the checksum
    valid = True
    for k in range(0, len(checksum)):
        if not checksum[k] == ordered[k][0]:
            valid = False

    if valid:
        # Get the sector id
        sectorid = int(re.search("\d+", namefull).group(0))

        name = list(name)

        for l in range(0, len(name)):
            if name[l] == '-':
                name[l] = " "
            else:
                index = alphabet.index(name[l])
                for q in range(0, sectorid):
                    index += 1
                    if index >= len(alphabet):
                        index = 0
                name[l] = alphabet[index]
        if "obj" in "".join(name):
            print("".join(name), sectorid)
