f = open('24_demo.txt')
s = f.readline()

maxlen = 0
begin = 0
end = 0
while end < len(s) - 1:
    end += 1
    if s[end] == s[end - 1]:
        maxlen = max(maxlen, end - begin)
        begin = end
maxlen = max(maxlen, end - begin + 1)
print(maxlen)