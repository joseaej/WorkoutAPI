using System.Runtime.Serialization;

namespace WorkoutApi.Utils
{
    public class GetEnums
    {
        public static string GetEnumStringValue<T>(T value)
        {
            var type = typeof(T);
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
            return ((EnumMemberAttribute)attributes[0]).Value;
        }
    }
}
