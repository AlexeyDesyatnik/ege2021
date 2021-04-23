# Переборное решение для проверки

f = open("27-A.txt")

n = int(f.readline())
nums = [int(line) for line in f]

max_triple = 0
for i in range(len(nums)):
    for j in range(i + 1, len(nums)):
        for k in range(j + 1, len(nums)):
            s = nums[i] + nums[j] + nums[k]
            if s % 3 == 0 and s > max_triple:
                max_triple = s

print(max_triple)