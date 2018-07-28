namespace CookAssistant.Stages
{
    public class Result
    {
        public string Text { get; }
        public bool IsFinish { get; }

        public Result(string text)
        {
            Text = text;
        }
    }
}