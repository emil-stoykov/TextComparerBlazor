namespace TextComparer.Data
{
    public class ResultService
    {
        public ResultService() {
            Result = new Result();
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
            Result.TotalLines = Math.Min(text1.Length, text2.Length);

            for (int line = 0; line < Result.TotalLines; line++)
            {
                if (!text1[line].Equals(text2[line]))
                {
                    Result.IsErrorless = false;
                    Result.LinesWithError.Add(line);
                } 
            }

            return await Task.FromResult(Result);
        }
    }
}
