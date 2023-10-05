using System.ComponentModel.DataAnnotations;

namespace TextComparer.Data
{
    public class CompareText
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Text field cannot be empty.")]
        [StringLength(65025, ErrorMessage = "Cannot exceed the text threshold.")]
        public string FirstText { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Text field cannot be empty.")]
        [StringLength(65025, ErrorMessage = "Cannot exceed the text threshold.")]
        public string SecondText { get; set; }  

    }
}
