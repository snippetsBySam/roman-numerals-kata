using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TemplateConsoleApp
{
    public class RomanKata
    {
        static readonly Dictionary<int, string> NumberToRomanDict = new()
        {
            { 1, "I" },
            { 4, "IV" },
            { 5, "V" },
            { 9, "IX" },
            { 10, "X" },
            { 40, "XL" },
            { 50, "L" },
            { 90, "XC" },
            { 100, "C" },
            { 400, "CD" },
            { 500, "D" },
            { 900, "CM" },
            { 1000, "M" }
        };

        static readonly Dictionary<char, int> RomanToNumberDict = new()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 },

        };


        public string ConvertToRoman(int number)
        {
            if (number > 4000 || number < 1)
            {
                throw new ArgumentException($"Number must be between 1 - 4000");
            }
            int currentMax = number;
            StringBuilder result = new();

            // Get maximum roman number that can be substracted from numberToConvert
            currentMax = NumberToRomanDict.Where(dict => dict.Key <= currentMax).Max(dict => dict.Key);
            result.Append(NumberToRomanDict[currentMax]);
            if (currentMax < number)
            {
                // recursion
                result.Append(ConvertToRoman(number - currentMax));
            }
            return result.ToString();
        }

        public int ConvertToArabic(string romanNumeral)
        {
            Regex ValidRomanPattern = new Regex(@"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
            if (!ValidRomanPattern.IsMatch(romanNumeral))
            {
                throw new ArgumentException($"\"{romanNumeral}\" is not a valid Roman Numeral");
            }
            romanNumeral = romanNumeral.ToUpper();
            char[] keys = RomanToNumberDict.Keys.ToArray();
            bool validRomanString = romanNumeral.All(x => keys.Contains(x));
            if (validRomanString)
            {
                int sum = 0;
                int numberOfNumerals = romanNumeral.Length;
                for (int i = 0; i < numberOfNumerals; i++)
                {
                    if ((i + 1) < numberOfNumerals)
                    {
                        if (RomanToNumberDict[romanNumeral[i]] < RomanToNumberDict[romanNumeral[i + 1]])
                        {
                            sum -= RomanToNumberDict[romanNumeral[i]];
                        }
                        else
                        {
                            sum += RomanToNumberDict[romanNumeral[i]];
                        }
                    }
                    else
                    {
                        sum += RomanToNumberDict[romanNumeral[i]];
                    }
                }
                return sum;
            }
            return 0;
        }

    }
}
