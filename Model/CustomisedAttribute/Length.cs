using System;

namespace Model.CustomisedAttribute
{
    public class LengthAttribute : Attribute
    {
        private LengthAttribute() { }

        public LengthAttribute(int offset, int length)
        {
            Offset = offset;
            Length = length;
        }

        public int Offset { get; private set; }

        public int Length { get; private set; }
    }
}
