using System.ComponentModel.DataAnnotations;

namespace TextComparer.Data
{
    public enum TextEnum
    {
        FIRST,
        SECOND
    }
    public class CompareText
    {
        [Required(ErrorMessage = "Text field cannot be empty.")]
        [StringLength(65025, ErrorMessage = "Cannot exceed the text threshold.")]
        public string FirstTextInput { get; set; }

        [Required(ErrorMessage = "Text field cannot be empty.")]
        [StringLength(65025, ErrorMessage = "Cannot exceed the text threshold.")]
        public string SecondTextInput { get; set; }

        [StringLength(65025, ErrorMessage = "Cannot exceed the text threshold.")]
        public string[] FirstTextArr { get; set; }

        [StringLength(65025, ErrorMessage = "Cannot exceed the text threshold.")]
        public string[] SecondTextArr { get; set; }

        public TextEnum copyTextEnum { get; set; } = TextEnum.FIRST;

        public string GetFullText(TextEnum val)
        {
            if (val == TextEnum.FIRST)
            {
                return string.Join(Environment.NewLine, FirstTextArr);
            } else {
                return string.Join(Environment.NewLine, SecondTextArr);
            }
        }
    }
}
