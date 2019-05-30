using Model.CustomisedAttribute;

namespace Model
{
    public class Student
    {
        [Ignore]
        public string Name { get; set; }

        public string Gender { get; set; }
    }
}
