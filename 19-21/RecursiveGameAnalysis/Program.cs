/*
Универсальное рекурсивное решение задач по теории игр (19-21).

Задание 19 № 27416

Два игрока, Петя и Ваня, играют в следующую игру. Перед игроками лежат две кучи
камней. Игроки ходят по очереди, первый ход делает Петя. За один ход игрок может
добавить в одну из куч (по своему выбору) один камень или увеличить количество
камней в куче в два раза.

В начальный момент в первой куче было семь камней, во второй куче — S камней; 1
≤ S ≤ 69. Игра завершается в тот момент, когда суммарное количество камней в
кучах становится не менее 77.

19: Известно, что Ваня выиграл своим первым ходом после неудачного первого хода
Пети. Укажите минимальное значение S, когда такая ситуация возможна

20: Найдите два таких значения S, при которых у Пети есть выигрышная стратегия,
причём одновременно выполняются два условия:

— Петя не может выиграть за один ход;

— Петя может выиграть своим вторым ходом независимо от того, как будет ходить
Ваня.

Найденные значения запишите в ответе в порядке возрастания без разделительных
знаков.

21: Найдите минимальное значение S, при котором одновременно выполняются два
условия:

— у Вани есть выигрышная стратегия, позволяющая ему выиграть первым или вторым
ходом при любой игре Пети;

— у Вани нет стратегии, которая позволит ему гарантированно выиграть первым
ходом.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursiveGameAnalysis
{
    class GameState
    {
        int heap1, heap2;

        public GameState(int h1, int h2)
        {
            heap1 = h1;
            heap2 = h2;
        }

        public List<GameState> GetNextStates()
        {
            return new List<GameState> {
                new GameState(heap1 + 1, heap2),
                new GameState(heap1 * 2, heap2),
                new GameState(heap1, heap2 + 1),
                new GameState(heap1, heap2 * 2),
            };
        }

        public bool IsWinningState()
        {
            return heap1 + heap2 >= 77;
        }
    }

    class Program
    {
        static int Analyze(GameState state, int depth, int maxDepth)
        {
            // Зашли слишком глубоко, ситуация непонятна
            if (depth > maxDepth) return 0;
            // Если хотя бы одно из следующих состояний - победа, то
            // state - выигрыш за один ход
            var nextStates = state.GetNextStates();
            foreach (var st in nextStates)
            {
                if (st.IsWinningState()) return 1;
            }
            // Погружаемся в рекурсивный анализ состояний игры
            var analysisResult = nextStates
                    .Select(st => Analyze(st, depth + 1, maxDepth))
                    .ToList();
            // Вариант 1: все ходы противника выигрышные (> 0)
            // В этом случае мы проигрываем за такое же кол-во ходов
            if (analysisResult.All(a => a > 0))
            {
                var maxMoves = analysisResult.Max();
                return maxMoves * -1;
            }
            // Вариант 2: хотя бы один ход противника проигрышный (< 0)
            // В этом случае берём самый короткий путь к выигрышу
            if (analysisResult.Any(a => a < 0))
            {
                var maxNeg = analysisResult.FindAll(a => a < 0).Max();
                return maxNeg * -1 + 1;
            }
            // В остальных случаях ситуация непонятна
            return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Решение 19 задачи");
            for (var s = 1; s <= 69; s++)
            {
                var nextStates = new List<int> {
                    Analyze(new GameState(7 + 1, s), 0, 4),
                    Analyze(new GameState(7 * 2, s), 0, 4),
                    Analyze(new GameState(7, s + 1), 0, 4),
                    Analyze(new GameState(7, s * 2), 0, 4),
                };
                if (nextStates.Any(a => a == 1))
                {
                    Console.WriteLine(s);
                    break;
                }
            }

            Console.WriteLine("Решение 20 задачи");
            for (var s = 1; s <= 69; s++)
            {
                var st = new GameState(7, s);
                if (Analyze(st, 0, 4) == 2)
                    Console.WriteLine(s);
            }

            Console.WriteLine("Решение 21 задачи");
            for (var s = 1; s <= 69; s++)
            {
                var st = new GameState(7, s);
                if (Analyze(st, 0, 4) == -2)
                    Console.WriteLine(s);
            }
        }
    }
}
