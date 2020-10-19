using Model.CustomisedAttribute;

namespace Model
{
    public class Student
    {
        [Ignore]
        public string Name { get; set; }

        public string Gender { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1}", this.Gender, this.Name);
        }
    }
}
