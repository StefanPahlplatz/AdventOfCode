import hashlib

h = ""
index = 0

for i in range(0, 8):
    while not h[:5] == "00000":
        string = "reyedfim" + str(index)
        h = hashlib.md5(string.encode('utf-8')).hexdigest()
        index += 1
    print(h[5])
    h = ""
