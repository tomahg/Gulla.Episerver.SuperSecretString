using System.Collections.Generic;

namespace Gulla.Episerver.SuperSecretString
{
    internal static class WhitespaceConstants
    {
        private static class InstructionModificationParameters
        {
            internal const string ImpIo = "\t\r\n";
            internal const string ImpStackManipulation = " ";
            internal const string ImpArithmetic = "\t ";
            internal const string ImpFlowControl = "\r\n";
            internal const string ImpHeapAccess = "\t\t";
        }

        private static class StackManipulation
        {
            internal const string PushNumber = " ";
            internal const string Duplicate = "\r\n ";
        }

        private static class IO
        {
            internal const string OutputCharacter = "  ";
            internal const string OutputNumber = " \t";
        }

        internal static class Number
        {
            internal const string PrefixPositive = " ";
            internal const string PrefixNegative = "\t";
            internal const string EndOfNumber = "\r\n";
            
            internal static readonly Dictionary<char, char> Mapping = new Dictionary<char, char>
            {
                {'0', ' ' },
                {'1', '\t' },
                {' ', '0' },
                { '\t', '1'}
            };
        }

        private static class FlowControl
        {
            internal const string EndOfProgram = "\r\n\r\n";
        }

        internal static class Sequence
        {
            internal const string PushNumber = InstructionModificationParameters.ImpStackManipulation + StackManipulation.PushNumber;
            internal const string OutputCharacter = InstructionModificationParameters.ImpIo + IO.OutputCharacter;
            internal const string EndOfProgram = InstructionModificationParameters.ImpFlowControl + FlowControl.EndOfProgram;
        }
    }
}