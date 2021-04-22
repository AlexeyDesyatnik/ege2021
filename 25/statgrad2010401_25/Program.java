/*
Найдите все натуральные числа, принадлежащие отрезку 
[35 000 000; 40 000 000],
у которых ровно пять различных нечётных делителей (количество чётных
делителей может быть любым). В ответе перечислите найденные числа
в порядке возрастания.
*/

class Program {
    static int countOddDivisors(int n) {
        int count = 0;
        for (int d = 1; d * d <= n; d++) {
            if (n % d == 0) {
                if (d % 2 != 0) {
                    count++;
                }
                int other = n / d;
                if (other != d && other % 2 != 0) {
                    count++;
                }
                if (count > 5) return -1;
            }
        }
        return count;
    }

    public static void main(String[] args) {
        for (int n = 35_000_000; n <= 40_000_000; n++) {
            if (countOddDivisors(n) == 5)
                System.out.println(n);
        }
    }
}