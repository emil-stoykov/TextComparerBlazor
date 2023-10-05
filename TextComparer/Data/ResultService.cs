using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
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
            this.Result.ResultState = ResultStates.PROCESSING;
            this.Result.TotalLines = Math.Min(text1.Length, text2.Length);

            for (int line = 0; line < Result.TotalLines; line++)
            {
                if (!text1[line].Equals(text2[line]))
                {
                    this.Result.LinesWithError.Add(line);
                }
            }

            return await Task.FromResult(this.Result);
        }

        public async Task<string[]> MarkErrorPointAsync(string text1, string text2)
        {
            int minLen = Math.Min(text1.Length, text2.Length);
            for (int i = 0; i < minLen; i++)
            {
                if (!text1[i].Equals(text2[i]))
                {
                    // TODO: Edit this if it doesn't show the text correctly.
                    return await Task.FromResult(new string[] { text2.Substring(0, i), text2.Substring(i, text2.Length - i).Trim() });
                }
            }

            return await Task.FromResult(new string[] { text2, string.Empty });
        }
    }
}
