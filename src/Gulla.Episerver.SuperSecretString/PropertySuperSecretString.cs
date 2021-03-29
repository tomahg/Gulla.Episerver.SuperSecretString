using System;
using EPiServer.Core;
using EPiServer.PlugIn;

namespace Gulla.Episerver.SuperSecretString
{
    [PropertyDefinitionTypePlugIn(
        DisplayName = "Super Secret String",
        Description = "A property for storing a super secret string out of sight",
        GUID = "CF6063F9-0D9E-41EA-8FC6-04809C3DA8FD")]
    public class PropertySuperSecretString : PropertyLongString
    {

        public override object SaveData(PropertyDataCollection properties)
        {
            return LongString;
        }

        public override Type PropertyValueType => typeof(string);

        public override object Value
        {
            get => Decode(LongString);
            set
            {
                var superSecretString = Encode(value);
                SetPropertyValue(superSecretString, () => LongString = superSecretString);
            }
        }

        private static string Encode(object input)
        {
            if (input is string str)
            {
                if (!str.IsWhitespaceProgram())
                {
                    return str.ToWhitespaceProgram();
                }
                return str;
            }

            return null;
        }

        private static string Decode(string input)
        {
            return input.ToWhitespaceResult();
        } 
    }
}