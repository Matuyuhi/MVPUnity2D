#region

using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

#endregion

namespace Core.Utilities
{
    public static class DebugEx
    {
        private const bool IsDebug = true;

        public static void LogDetailed(object message)
        {
#pragma warning disable CS0162
            if (!IsDebug)
            {
                return;
            }
#pragma warning restore CS0162

            if (message == null)
            {
                Debug.Log("Null");
                return;
            }

            if (message.GetType().IsArray || message is IList)
            {
                var enumerable = message as IEnumerable;
                var index = 0;
                if (enumerable != null)
                {
                    foreach (var item in enumerable)
                    {
                        Debug.Log(
                            $"{message.GetType().GetElementType()?.Name ?? message.GetType().Name}[{index}] = {item}");
                        index++;
                    }
                }
            }
            else if (message.GetType().IsValueType || message is string)
            {
                Debug.Log(message);
            }
            else
            {
                var fields = message.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                var properties = message.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var details = $"{message.GetType().Name}:";

                foreach (var field in fields)
                {
                    details += $"\n {field.Name} = {field.GetValue(message)}";
                }

                foreach (var property in properties)
                {
                    // 非推奨のプロパティをスキップする
                    if (property.GetCustomAttributes(typeof(ObsoleteAttribute), true).Length > 0)
                    {
                        continue;
                    }

                    try
                    {
                        details += $"\n {property.Name} = {property.GetValue(message)}";
                    }
                    catch (TargetInvocationException ex)
                    {
                        if (ex.InnerException != null)
                        {
                            details +=
                                $"\n {property.Name} = cannot retrieve value (Exception: {ex.InnerException.Message})";
                        }
                    }
                }

                Debug.Log(details);
            }
        }
    }
}