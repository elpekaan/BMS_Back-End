using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities;

public static class GenericExtensions
{
    public static DateTime ToTimeZone(this DateTime dateTime, string timeZoneId = "Turkey Standard Time")
    {
        var zone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        var time = TimeZoneInfo.ConvertTime(dateTime, zone);
        return DateTime.SpecifyKind(time, DateTimeKind.Utc);
    }

    public static string ComputeHashUsingSHA256(this string @string)
    {
        var stringBuilder = new StringBuilder();

        using (var hash = SHA256.Create())
        {
            var computedHashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(@string));

            foreach (var computedHashByte in computedHashBytes)
            {
                stringBuilder.Append(computedHashByte.ToString("x2"));
            }
        }

        return stringBuilder.ToString();
    }
}