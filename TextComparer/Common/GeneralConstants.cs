namespace TextComparer.Common
{
    public static class GeneralConstants
    {
        /// <summary>
        /// const string for opening a span element for highlighting the error.
        /// </summary>
        public const string SpanStart = "<span style='background-color: lightcoral'>";
        /// <summary>
        /// const string for closing a span element that highlights the error.
        /// </summary>
        public const string SpanEnd = "</span>";

        /// <summary>
        /// const string for showing the error message about the empty textfields.
        /// </summary>
        public const string EmptyTextareaError = "Both fields should not be empty.";

        public const string NotifNoErrors = "No errors were found.";

        public const string NotifWithErrors = "Total errors: ";
    }
}
