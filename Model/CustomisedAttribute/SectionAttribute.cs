using System;

namespace Model.CustomisedAttribute
{
    /// <summary>
    /// 长度
    /// </summary>
    public class SectionAttribute : Attribute
    {
        private SectionAttribute() { }

        public SectionAttribute(int index, int length)
        {
            Index = index;
            Length = length;
        }

        public int Index { get; private set; }

        public int Length { get; private set; }
    }
}
