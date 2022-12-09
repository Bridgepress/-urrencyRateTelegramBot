namespace TelegramBot.Handler.Helpers
{
    public static class EnumHelper<T>
    {
        public static T Parse(string value)
        {
            T result;
            try
            {
                result = (T)Enum.Parse(typeof(T), value, true);
            }
            catch (Exception)
            {
                result = default(T);
            }
            return result;
        }
    }
}
