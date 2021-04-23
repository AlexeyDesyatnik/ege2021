f = open("27-B.txt")

f.readline()

rem0 = []
rem1 = []
rem2 = []

for line in f:
    n = int(line)
    if n % 3 == 0:
        rem0.append(n)
    elif n % 3 == 1:
        rem1.append(n)
    else:
        rem2.append(n)
rem0.sort(reverse=True)
rem1.sort(reverse=True)
rem2.sort(reverse=True)

# Можно не проверять длину списков,
# т.к. во всех трёх списках достаточно чисел
# из обоих рабочих файлов
candidates = [
    # 0 0 0
    sum(rem0[:3]),
    # 0 1 2
    sum([rem0[0] + rem1[0] + rem2[0]]),
    # 1 1 1
    sum(rem1[:3]),
    # 2 2 2
    sum(rem2[:3]),    
]
print(max(candidates))