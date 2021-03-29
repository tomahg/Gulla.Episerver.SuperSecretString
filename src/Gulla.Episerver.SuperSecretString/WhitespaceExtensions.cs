using System;
using System.Collections;
using System.Linq;

namespace Gulla.Episerver.SuperSecretString
{
    internal static class WhitespaceExtensions
    {
        internal static string ToWhitespaceProgram(this string str)
        {
            return str.Aggregate("", (current, chr) => current + chr.ToWhitespaceNumberPrinted()) + WhitespaceConstants.Sequence.EndOfProgram;
        }

        internal static string ToWhitespaceResult(this string str)
        {
            if (str == null)
            {
                return null;
            }

            var stack = new Stack();
            var output = "";
            var restOfProgram = str;
            var lastRound = ""; // So we don't get stuck forever...
            while (restOfProgram.Length > 0 && restOfProgram != WhitespaceConstants.Sequence.EndOfProgram && lastRound != restOfProgram)
            {
                lastRound = restOfProgram;

                if (restOfProgram.StartsWith(WhitespaceConstants.Sequence.PushNumber))
                {
                    restOfProgram = ReadNumberPushToStackReturnRest(restOfProgram.Substring(WhitespaceConstants.Sequence.PushNumber.Length), stack);
                }
                else if (restOfProgram.StartsWith(WhitespaceConstants.Sequence.OutputCharacter))
                {
                    restOfProgram = OutputCharacterPopStack(restOfProgram.Substring(WhitespaceConstants.Sequence.OutputCharacter.Length), stack, ref output);
                }
            }

            return output;
        }

        private static string ReadNumberPushToStackReturnRest(string program, Stack stack)
        {
            var whitespaceNumberString = program.Substring(0, program.IndexOf("\r\n", StringComparison.InvariantCultureIgnoreCase));
            var binary = GetBinaryFromWhitespace(whitespaceNumberString);
            var number = Convert.ToInt32(binary, 2);
            stack.Push(number);
            return program.Substring(whitespaceNumberString.Length + "\r\n".Length);
        }

        private static string OutputCharacterPopStack(string program, Stack stack, ref string output)
        {
            if (stack.Peek() != null)
            {
                var number = (int) stack.Pop();
                output += (char) number;
            }

            return program;
        }

        internal static bool IsWhitespaceProgram(this string str)
        {
            if (str == null)
            {
                return false;
            }

            return str.StartsWith(WhitespaceConstants.Sequence.PushNumber) && str.EndsWith(WhitespaceConstants.Sequence.EndOfProgram);
        }

        private static string ToWhitespaceNumberPrinted(this char chr)
        {
            return  WhitespaceConstants.Sequence.PushNumber + chr.ToWhitespaceNumber() + WhitespaceConstants.Sequence.OutputCharacter;
        }

        private static string ToWhitespaceNumber(this char chr)
        {
            var ascii = (int)chr;
            var binary = Convert.ToString(ascii, 2);
            var whitespaceNumber = WhitespaceConstants.Number.PrefixPositive + GetWhitespaceEncodedBinary(binary) + WhitespaceConstants.Number.EndOfNumber;
            return whitespaceNumber;
        }

        private static string GetWhitespaceEncodedBinary(string binary)
        {
            return binary
                .Replace('0', WhitespaceConstants.Number.Mapping['0'])
                .Replace('1', WhitespaceConstants.Number.Mapping['1']);
        }

        private static string GetBinaryFromWhitespace(string whitespace)
        {
            return whitespace
                .Replace(' ', WhitespaceConstants.Number.Mapping[' '])
                .Replace('\t', WhitespaceConstants.Number.Mapping['\t']);
        }
    }
}