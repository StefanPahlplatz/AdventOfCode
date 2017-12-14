def solve(input):
    size = 3
    total = 1
    i = 1
    while total < input:
        total += size * 4 - 4
        if total < input:
            size += 2
            i += 1
    while total > input:
        high = total
        total -= size - 1
        if total <= input:
            return abs((high - i) - input) + abs(i)


assert solve(347991) == 480
