"""
Пусть M (N) – произведение 5 наименьших различных натуральных
делителей натурального числа N, не считая единицы. Если у числа N меньше
5 таких делителей, то M (N) считается равным нулю.
Найдите 5 наименьших натуральных чисел, превышающих 200 000 000, для
которых 0 < M (N) < N.
В ответе запишите найденные значения M (N) в порядке возрастания
соответствующих им чисел N.
"""

def getDivisors(n):
    divisors = []
    d = 2
    while d * d < n:
        if n % d == 0:
            divisors.append(d)
        d += 1
    if d * d == n:
        divisors.append(d)
    return sorted(divisors)

def m(n):
    firstFiveDivisors = getDivisors(n)[:5]
    if len(firstFiveDivisors) < 5:
        return 0
    p = 1
    for d in firstFiveDivisors:
        p *= d
    return p

count = 0
for n in range(200_000_001, 300_000_000):
    _m = m(n)
    if 0 < _m < n:
        print(_m)
        count += 1
        if count == 5:
            break