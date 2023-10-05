namespace TextComparer.Data
{
    public enum ResultStates
    {
        AWAITING,
        PROCESSING,
        FINISHED
    }
    
    public class Result
    {
        public Result() {
            LinesWithError = new List<int>();
        }

        public ResultStates ResultState { get; set; } = ResultStates.AWAITING;

        public int TotalLines { get; set; }

        public ICollection<int> LinesWithError { get; set; }

        public int ErrorCount => LinesWithError.Count;

        public string[] ModifiedText { get; set; }
    }
}
