using Newtonsoft.Json.Converters;

namespace APi.Utils;

public class Utils
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat=format;
        }
    }
}