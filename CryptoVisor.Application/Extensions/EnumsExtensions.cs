using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CryptoVisor.Application.Extensions
{
    public static class EnumsExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            try
            {
                return enumValue.GetType()
                                .GetMember(enumValue.ToString())
                                .First()
                                .GetCustomAttribute<DisplayAttribute>()
                                .GetName();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
