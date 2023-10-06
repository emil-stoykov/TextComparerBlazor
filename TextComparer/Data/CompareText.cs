using System.ComponentModel.DataAnnotations;

namespace TextComparer.Data
{
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
    }
}
