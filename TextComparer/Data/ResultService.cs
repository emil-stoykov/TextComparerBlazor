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
            this.Result.TotalLines = Math.Min(text1.Length, text2.Length);
            string textToCheck = string.Empty;
            char errorChar = '\0';
            for (int line = 0; line < Result.TotalLines; line++)
            {
                textToCheck = text2[line];

                if (!text1[line].Equals(text2[line]))
                {
                    this.Result.IsErrorless = false;
                    this.Result.LinesWithError.Add(line);

                    for (int i = 0; i < Math.Min(text1[line].Length, text2[line].Length); i++)
                    {
                        if (text1[line][i] != text2[line][i])
                        {
                            errorChar = text2[line][i]; 
                            break;
                        }
                    }

                    string[] splitText = text2[line].Split(errorChar);
                    textToCheck = splitText[0] + SpanStart + splitText[1] + SpanEnd;
                } 

                this.Result.ModifiedText.Concat(textToCheck);
            }

            return await Task.FromResult(this.Result);
        }
    }
}
