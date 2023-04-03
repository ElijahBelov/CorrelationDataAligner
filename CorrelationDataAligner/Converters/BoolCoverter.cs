using System;

namespace CorrelationDataAligner.Converters
{
    internal class BoolCoverter
    {
        internal static bool GetBool(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            return bool.Parse(input);
        }
    }
}