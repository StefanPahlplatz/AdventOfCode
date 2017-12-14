import hashlib


def intTryParse(value):
    try:
        return int(value)
    except ValueError:
        return 9


answer = ['_'] * 8
h = ""
index = 0

for i in range(0, 8):
    gotchar = False
    while not gotchar:
        string = "reyedfim" + str(index)
        h = hashlib.md5(string.encode('utf-8')).hexdigest()
        index += 1

        if h[:5] == "00000":
            position = intTryParse(h[5])
            if position < 8:
                if answer[position] == "_":
                    answer[position] = h[6]
                    print("".join(answer))
                    h = ""
                    gotchar = True

