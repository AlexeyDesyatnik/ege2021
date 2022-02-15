f = open("24-181.txt")
s = f.readline()

for vowel in 'AEIOUY':
    s = s.replace(vowel, ' ')
substrings = s.split()
maxlen = 0
for substring in substrings:
    if substring.count('.') >= 6:
        maxlen = max(maxlen, len(substring))

print(maxlen)