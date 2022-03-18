# Две кучи с ограничением суммы
# kpolyakov.spb.ru №4733


def get_next_positions(position):
    a, b = position
    return [
        [a + 1, b],
        [a * 2, b],
        [a, b + 1],
        [a, b * 2]
    ]

# 0 - позиция в игре
# 1 - последний игрок выиграл
# -1 - последний игрок проиграл
def is_winning(position):
    a, b = position
    s = a + b
    if s < 91:
        return 0
    if s <= 110:
        return 1
    return -1


# Предполагается, что position ещё не победная сама по себе
def analyze(position, curr_depth, max_depth):
    if curr_depth > max_depth:
        return 0
    next_positions = get_next_positions(position)
    check_winning = [is_winning(p) == 1 for p in next_positions]
    if any(check_winning):
        return 1
    check_losing = [is_winning(p) == -1 for p in next_positions]
    if all(check_losing):
        return -1
    game_positions = [p for p in next_positions if is_winning(p) == 0]
    next_analysis = [analyze(p, curr_depth + 1, max_depth) for p in game_positions]
    check_positive = [a > 0 for a in next_analysis]
    if all(check_positive):
        return max(next_analysis) * -1
    only_negative = [a for a in next_analysis if a < 0]
    if len(only_negative) > 0:
        return max(only_negative) * -1 + 1
    return 0

# print(analyze([40, 49], 0, 4))

print("# 19")
for s in range(1, 51):
    if analyze([40, s], 0, 4) == -1:
        print(s)
        break


print("# 20")
for s in range(1, 51):
    if analyze([40, s], 0, 4) == 2:
        print(s)

print("# 21")
for s in range(1, 51):
    if analyze([40, s], 0, 4) == -2:
        print(s)