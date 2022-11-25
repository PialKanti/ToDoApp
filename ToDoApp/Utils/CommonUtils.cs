namespace ToDoApp.Utils
{
    public class CommonUtils
    {
        public static int GetTimestamp(DateTime dateTime)
        {
            var timeSpan = (dateTime - new DateTime(1970, 1, 1, 0, 0, 0));
            return (int)timeSpan.TotalSeconds;
        }
    }
}
