import numpy as np
import re

screen = np.chararray((6, 50))
screen[:] = '.'


def rect(x_, y_):
    for y in range(0, y_):
        for x in range(0, x_):
            screen[y][x] = '#'


def rotate_row(y, times):
    for i in range(0, times):
        original_last = screen[y, -1]
        for x in reversed(range(0, 50)):
            screen[y, x] = screen[y, x - 1] if x != 0 else original_last


def rotate_column(x, times):
    for i in range(0, times):
        original_last = screen[-1, x]
        for y in reversed(range(0, 6)):
            screen[y, x] = screen[y - 1, x] if y != 0 else original_last

for line in open("day8.txt"):
    r = re.findall("\d+", line)
    if "rect" in line:
        rect(int(r[0]), int(r[1]))
    elif "column" in line:
        rotate_column(int(r[0]), int(r[1]))
    else:
        rotate_row(int(r[0]), int(r[1]))
print('\n\n'.join(' '.join(str(cell)[1:] for cell in row) for row in screen))

