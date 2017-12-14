input = 347991

size = 3
total = 1
i = 1
while total < input:
    amount = size * 4 - 4
    print('in ring {} fit {} values'.format(i, amount))
    print('total {} for ring {} with side size of {}'.format(total + amount, i, size))
    total += amount

    if total < input:
        size += 2
        i += 1

print('difference = {}'.format(total - input))
print('value is in ring {} bottom right value is {} sides are {}'.format(i, total, size))

sides = ['bottom', 'left', 'top', 'right']
side = 0
low, high = 0, 0
while (total - size) + size > input:
    print('{} - {}'.format(total, total - size + 1))
    high = total
    total -= size - 1
    low = total
    if (total - size) + size > input:
        side += 1

print('value in the {} row'.format(sides[side]))
print('middle value {}'.format(high - i))
print((high - i) - input)

if side == 0 or side == 2:
    x = (high - i) - input
    y = i
else:
    y = (high - i) - input
    x = i

print(x, y)
print('distance: {}'.format(abs(x) + abs(y)))
