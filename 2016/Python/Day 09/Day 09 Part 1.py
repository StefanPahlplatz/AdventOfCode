import re

with open('day9.txt') as file:
    data = file.read().replace(' ', '')
length = 0
while len(data) > 0:
    if data[0] == '(':
        marker = data[data.index('('):data.index(')') + 1]
        keys = re.findall('\d+', marker)
        data = data[data.index(')') + 1 + int(keys[0]):]
        length += int(keys[0]) * int(keys[1])
    else:
        length += 1
        data = data[1:]
print("Answer:", length)
