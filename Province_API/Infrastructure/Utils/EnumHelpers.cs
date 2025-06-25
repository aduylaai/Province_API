using System.Reflection;
using System.Runtime.Serialization;

namespace Province_API.Infrastructure.Utils
{
    public static class EnumHelpers
    {
        public static string GetEnumMemberValue(this Enum enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            var attribute = memberInfo?.GetCustomAttribute<EnumMemberAttribute>(false);
            return attribute?.Value ?? enumValue.ToString();
        }

        public static T ParseEnumMemberValue<T>(string value) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                var attribute = field.GetCustomAttribute<EnumMemberAttribute>();
                if (attribute?.Value == value)
                    return (T)field.GetValue(null);
            }

            throw new ArgumentException($"Unknown value '{value}' for enum '{typeof(T).Name}'");
        }
    }
}
