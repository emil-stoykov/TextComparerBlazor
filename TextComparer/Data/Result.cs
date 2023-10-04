namespace TextComparer.Data
{
    public class Result
    {
        public Result() {
            LinesWithError = new List<int>();
        }

        public int TotalLines { get; set; }

        public ICollection<int> LinesWithError { get; set; }

        public int ErrorLines => LinesWithError.Count;

        public bool IsErrorless { get; set; } = true;

        public string ModifiedText { get; set; } 
    }
}
