using static TextComparer.Common.GeneralConstants;

namespace TextComparer.Data
{
    public class ResultService
    {
        public ResultService() {
            this.Result = new Result();
        }
        public Result Result { get; set; }


        /// <summary>
        /// An asynchronous method that compares two texts line by line. Returns a "Result" object.
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <returns></returns>
        public async Task<Result> CheckLines(string[] text1, string[] text2)
        {
            string textToCheck = string.Empty;
            char errorChar = '\0';
            this.Result.TotalLines = Math.Min(text1.Length, text2.Length);

            for (int line = 0; line < Result.TotalLines; line++)
            {
                textToCheck = text2[line];

                if (!text1[line].Equals(text2[line]))
                {
                    this.Result.IsErrorless = false;
                    this.Result.LinesWithError.Add(line);

                    errorChar = FindErrorPoint(text1[line], text2[line]);

                    if (errorChar != '\0')
                    {
                        string[] splitText = text2[line].Split(errorChar);
                        textToCheck = splitText[0] + SpanStart + errorChar + splitText[1] + SpanEnd;
                    }
                } 

                this.Result.ModifiedText.Concat(textToCheck);
            }

            return await Task.FromResult(this.Result);
        }

        private char FindErrorPoint(string text1, string text2)
        {
            for (int i = 0; i < Math.Min(text1.Length, text2.Length); i++)
            {
                if (text1[i] != text2[i])
                {
                    return text2[i];
                }
            }

            return '\0';
        }
    }
}
