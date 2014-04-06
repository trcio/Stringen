using System;
using System.Linq;

namespace Stringen
{
    public enum GenType
    {
        Alphabetic,
        Numeric,
        Alphanumeric,
    }

    public enum GenCase
    {
        Lower,
        Upper,
        Mixed
    }

    public static class Generator
    {
        private const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string numbers = "0123456789";
        private static Random rand = new Random();

        public static string GenerateSimple(SimpleOptions options)
        {
            var elements = new string[options.Elements];
            for (int i = 0; i < options.Elements; i++)
            {
                elements[i] = GenerateElement(options);
            }
            return string.Join(options.Seperator, elements);
        }

        public static string GenerateComplex(ComplexOptions options)
        {
            var elements = new string[options.ElementOptions.Length];
            for (int i = 0; i < options.ElementOptions.Length; i++)
            {
                elements[i] = GenerateElement(options.ElementOptions[i]);
            }
            return string.Join(options.Seperator, elements);
        }

        private static string GenerateElement(SimpleOptions options)
        {
            var element = new char[options.ElementLength];
            var validChars = alphabet;

            switch (options.Type)
            {
                case GenType.Alphabetic: validChars = alphabet; break;
                case GenType.Alphanumeric: validChars = string.Concat(alphabet, numbers); break;
                case GenType.Numeric: validChars = numbers; break;
            }
            switch (options.Case)
            {
                case GenCase.Upper: validChars = validChars.ToUpper(); break;
                case GenCase.Lower: validChars = validChars.ToLower(); break;
                case GenCase.Mixed: validChars = string.Concat(validChars.ToUpper(), validChars.ToLower()); break;
            }

            validChars = string.Join("", validChars.OrderBy(x => rand.Next()).ToArray());

            for (int i = 0; i < options.ElementLength; i++)
            {
                element[i] = validChars[rand.Next(validChars.Length)];
            }

            return new string(element);
        }
    }

    public class ComplexOptions
    {
        public ComplexOptions() { }
        public ComplexOptions(string seperator, SimpleOptions[] options)
        {
            this.Seperator = seperator;
            this.ElementOptions = options;
        }

        public string Seperator { get; set; }
        public SimpleOptions[] ElementOptions { get; set; }
    }

    public class SimpleOptions
    {
        public SimpleOptions() { }
        public SimpleOptions(GenType genType, GenCase genCase, string seperator, int elements, int elementLength)
        {
            this.Type = genType;
            this.Case = genCase;
            this.Seperator = seperator;
            this.Elements = elements;
            this.ElementLength = elementLength;
        }

        public GenType Type { get; set; }
        public GenCase Case { get; set; }
        public string Seperator { get; set; }
        public int Elements { get; set; }
        public int ElementLength { get; set; }
    }
}