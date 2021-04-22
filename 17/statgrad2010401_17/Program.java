/*
Назовём натуральное число подходящим, если у него ровно 3 различных
простых делителя. Например, число 180 подходящее (его простые делители –
2, 3 и 5), а число 12 – нет (у него только два различных простых делителя).
Определите количество подходящих чисел, принадлежащих отрезку
[10 001; 50 000], а также наименьшее из таких чисел. В ответе запишите
два целых числа: сначала количество, затем наименьшее число.
*/

import java.util.*;

class Program {
    static boolean[] primes = new boolean[50001];
    static void makeSieve() {
        Arrays.fill(primes, true);
        for (int i = 2; i < primes.length; i++) {
            if (!primes[i]) continue;
            for (int j = 2 * i; j < primes.length; j += i)
                primes[j] = false;
        }
    }

    static boolean testNumber(int n) {
        int primeDivCount = 0;
        for (int d = 2; d < n; d++) {
            if (n % d == 0 && primes[d]) primeDivCount++;
        }
        return primeDivCount == 3;
    }

    public static void main(String[] args) {
        makeSieve();
        int count = 0;
        int min = 0;
        for (int i = 50_000; i >= 10_001; i--) {
            if (testNumber(i)) {
                count++;
                min = i;
            }
        }
        System.out.println(count);
        System.out.println(min);
    }
}