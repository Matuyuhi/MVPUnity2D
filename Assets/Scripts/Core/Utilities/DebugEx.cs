using System.Collections;
using System.Reflection;

namespace Core.Utilities
{
    public static class DebugEx
    {
        private const bool IsDebug = true;

        public static void LogDetailed(object message)
        {
            if (!IsDebug) return;

            if (message == null)
            {
                UnityEngine.Debug.Log("Null");
                return;
            }

            if (message.GetType().IsArray || message is IList)
            {
                IEnumerable enumerable = message as IEnumerable;
                int index = 0;
                foreach (var item in enumerable)
                {
                    UnityEngine.Debug.Log($"{message.GetType().GetElementType()?.Name ?? message.GetType().Name}[{index}] = {item}");
                    index++;
                }
            }
            else if (message.GetType().IsValueType || message is string)
            {
                UnityEngine.Debug.Log(message);
            }
            else
            {
                FieldInfo[] fields = message.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                PropertyInfo[] properties = message.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                string details = $"{message.GetType().Name}:";
            
                foreach (var field in fields)
                {
                    details += $"\n {field.Name} = {field.GetValue(message)}";
                }

                foreach (var property in properties)
                {
                    details += $"\n {property.Name} = {property.GetValue(message)}";
                }

                UnityEngine.Debug.Log(details);
            }
        }
    }
}