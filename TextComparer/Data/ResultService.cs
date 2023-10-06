using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.ObjectPool;
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
                if (!text1[line].Equals(text2[line]) || !text1[line].Length.Equals(text2[line].Length))
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

        public async Task<string[,]> GetDisplayTextAsync(Result resultObj, CompareText compareText)
        {
            string[,] displayTextArr = new string[compareText.SecondTextArr.Length, 2];

            // iterate over the text until the largest index is reached
            if (resultObj.ErrorCount != 0)
            {
                for (int i = 0; i <= resultObj.LinesWithError.Max(); i++)
                {
                    string[] errorTxt = new string[2];
                    if (resultObj.LinesWithError.Contains(i))
                    {
                        errorTxt = await MarkErrorPointAsync(compareText.FirstTextArr[i], compareText.SecondTextArr[i]);
                    }
                    else
                    {
                        errorTxt = new string[] { compareText.SecondTextArr[i], string.Empty };
                    }

                    displayTextArr[i, 0] = errorTxt[0];
                    displayTextArr[i, 1] = errorTxt[1];
                }
            }

            // fill the rest of the array
            for (int i = resultObj.ErrorCount != 0 ? resultObj.LinesWithError.Max() + 1 : 0; i < compareText.SecondTextArr.Length; i++)
            {
                displayTextArr[i, 0] = compareText.SecondTextArr[i];
            }

            return displayTextArr;
        }
    }
}
