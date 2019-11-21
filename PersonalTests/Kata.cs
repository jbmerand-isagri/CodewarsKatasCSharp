using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatasSolutions
{
    public class Kata
    {
        public static int CountBits(int n)
        {
            var binary = Convert.ToString(n, 2);
            var quantityOfOne = 0;

            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i].Equals('1'))
                {
                    quantityOfOne += 1;
                }
            }

            return quantityOfOne;
            // return Convert.ToString(n, 2).Count(x => x == '1');
        }

        public static bool IsNarcissistic(int value)
        {
            var stringOfTheValue = value.ToString();
            var quantityOfDigits = stringOfTheValue.Length;
            double sumOfDigits = 0;

            foreach (var character in stringOfTheValue)
            {
                sumOfDigits += Math.Pow(char.GetNumericValue(character), quantityOfDigits);
            }

            return sumOfDigits == value;
            // var str = value.ToString();
            // return str.Sum(c => Math.Pow(Convert.ToInt16(c.ToString()), str.Length)) == value;
        }

        public static int DuplicateCount(string str)
        {
            var count = 0;

            foreach (var character in str)
            {
                if (str.Count(c => char.ToLower(c) == char.ToLower(character)) > 1)
                {
                    count += 1;
                    str = str.Replace(char.ToLower(character), '#');
                    str = str.Replace(char.ToUpper(character), '#');
                }
            }
            return count;
            // return str.ToLower().GroupBy(c => c).Where(g => g.Count() > 1).Count();
            // return str.ToLower().GroupBy(c => c).Count(c => c.Count() > 1);
        }

        public static string RomanConvert(int n) // TODO: finish it, https://www.codewars.com/kata/51b62bf6a9c58071c600001b/train/csharp
        {
            string numberInString = n.ToString();
            int quantityOfDigitsInNumber = numberInString.Length;
            string numberInRomanNumerals = "";

            for (var i = 0; i < quantityOfDigitsInNumber; i++)
            {
                var digit = (int)(char.GetNumericValue(numberInString[i]) * Math.Pow(10, quantityOfDigitsInNumber - (i + 1)));

                var M = digit / 1000;
                digit -= M * 1000;

                var D = 0;
                var C = 0;

                if (digit / 100 == 9)
                {
                    M++;
                    C = 1;
                    digit -= 900;
                }
                else if (digit / 100 == 4)
                {
                    D = 1;
                    C = 1;
                    digit -= 400;
                }
                else
                {
                    D = digit / 500;
                    digit -= D * 500;
                    C += digit / 100;
                    digit -= C * 100;
                }

                var L = 0;
                var X = 0;

                if (digit / 10 == 9)
                {
                    C++;
                    X = 1;
                    digit -= 90;
                }
                else if (digit / 10 == 4)
                {
                    L = 1;
                    X = 1;
                    digit -= 40;
                }
                else
                {
                    L = digit / 50;
                    digit -= L * 50;

                    X = digit / 10;
                    digit -= X * 10;
                }

                var V = 0;
                var I = 0;

                if (digit == 9)
                {
                    X++;
                    I = 1;
                }
                else if (digit == 4)
                {
                    V = 1;
                    I = 1;
                }
                else
                {
                    V = digit / 5;
                    digit -= V * 5;

                    I = digit;
                }

                numberInRomanNumerals = string.Concat(numberInRomanNumerals, GetStringOfARomanNumerals(I, "I"));
                numberInRomanNumerals = string.Concat(numberInRomanNumerals, GetStringOfARomanNumerals(V, "V"));
                numberInRomanNumerals = string.Concat(numberInRomanNumerals, GetStringOfARomanNumerals(X, "X"));
                numberInRomanNumerals = string.Concat(numberInRomanNumerals, GetStringOfARomanNumerals(L, "L"));
                numberInRomanNumerals = string.Concat(numberInRomanNumerals, GetStringOfARomanNumerals(C, "C"));
                numberInRomanNumerals = string.Concat(numberInRomanNumerals, GetStringOfARomanNumerals(D, "D"));
                numberInRomanNumerals = string.Concat(numberInRomanNumerals, GetStringOfARomanNumerals(M, "M"));
            }
            Console.WriteLine(numberInRomanNumerals);
            Console.ReadKey();
            return numberInRomanNumerals;
        }

        public static string GetStringOfARomanNumerals(int quantityOfARomanNumeral, string romanNumeral)
        {
            var result = "";

            for (int i = 0; i < quantityOfARomanNumeral; i++)
            {
                result = string.Concat(result, romanNumeral);
            }

            return result;
        }

        public static string PigIt(string str)
        {
            var elements = str.Split(' ').ToList();
            var finalWords = new List<string>();

            foreach (var element in elements)
            {
                var finalWord = new StringBuilder();

                if (element.Length == 1 && char.IsPunctuation(char.Parse(element)))
                {
                    finalWord.Append(element);
                    finalWords.Add(finalWord.ToString());
                }
                else
                {
                    finalWord.Append(element.Substring(1));
                    finalWord.Append(element[0]);
                    finalWord.Append("ay ");
                    finalWords.Add(finalWord.ToString());
                }
            }

            return string.Concat(finalWords).Trim();
            // return string.Join(" ", str.Split(' ').Select(w => w.Substring(1) + w[0] + "ay"));
        }

        public static bool IsPrime(int n)
        {
            if (n < 0)
            {
                return false;
            }

            if (n == 0 || n == 1)
            {
                return false;
            }

            if ((n > 2 && n % 2 == 0) || (n > 3 && n % 3 == 0) || (n > 5 && n % 5 == 0) || (n > 7 && n % 7 == 0) || (n > 11 && n % 11 == 0))
            {
                return false;
            }

            for (int i = 3; i <= Math.Ceiling((Math.Sqrt(n))); i++)
            {
                if (n % i == 0 && i != n)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool comp(int[] a, int[] b) // TODO: finish it, https://www.codewars.com/kata/550498447451fbbd7600041c/train/csharp
        {
            if (a == null || b == null || a.Length == 0 || b.Length == 0)
            {
                return false;
            }

            var isAllNumbersOfAValid = true;

            b.ToList()
                .ForEach(n =>
                {
                    if (Math.Sqrt(n) != Math.Floor(Math.Sqrt(n)))
                    {
                        isAllNumbersOfAValid = false;
                    }
                });

            if (!isAllNumbersOfAValid)
            {
                return false;
            }

            var squaredNumbersOfA = a
                .ToList()
                .Select(n => n * n)
                .ToList();
            var squareRootNumbersOfB = b
                .ToList()
                .Select(n => Math.Sqrt(n))
                .ToList();

            foreach (var sn in squaredNumbersOfA)
            {
                if (!b.Contains(sn))
                {
                    return false;
                }
            }

            foreach (var srn in squareRootNumbersOfB)
            {
                if (!a.ToList().Contains(Convert.ToInt32(srn)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}