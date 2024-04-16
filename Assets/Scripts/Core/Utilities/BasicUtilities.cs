using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Core.Utilities
{
    public static class BasicUtilities
    {
        public static T CoerceIn<T>(T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            if (value.CompareTo(max) > 0) return max;
            return value;
        }
        
        public static T CoerceAtLeast<T>(T value, T min) where T : IComparable<T>
        {
            return value.CompareTo(min) < 0 ? min : value;
        }

        public static T CoerceAtMost<T>(T value, T max) where T : IComparable<T>
        {
            return value.CompareTo(max) > 0 ? max : value;
        }

        public static bool IsNullOrBlank(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static T Max<T>(params T[] values) where T : IComparable<T>
        {
            return values.Max();
        }

        public static T Min<T>(params T[] values) where T : IComparable<T>
        {
            return values.Min();
        }
        
        public static float Abs(float value)
        {
            return value < 0 ? -value : value;
        }
        
        public static double Abs(double value)
        {
            return value < 0 ? -value : value;
        }
        
        public static int Abs(int value)
        {
            return value < 0 ? -value : value;
        }

        public static bool IsNullOrEmpty<T>(IEnumerable<T> collection)
        {
            return collection == null || !collection.Any();
        }

        public static int Sum(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }

        public static decimal Average(IEnumerable<decimal> numbers)
        {
            return numbers.Average();
        }
        
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            foreach (var element in items)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static string Repeat(this string value, int count)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            return string.Concat(Enumerable.Repeat(value, count));
        }

        public static IEnumerable<T> TakeLast<T>(IEnumerable<T> source, int count)
        {
            var enumerable = source.ToList();
            return enumerable.Skip(Math.Max(0, enumerable.Count() - count));
        }

        public static IEnumerable<T> Drop<T>(IEnumerable<T> source, int count)
        {
            return source.Skip(count);
        }

        public static IEnumerable<T> TakeWhile<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.TakeWhile(predicate);
        }

        public static IEnumerable<T> DropWhile<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool yielding = false;
            foreach (var item in source)
            {
                if (!yielding && !predicate(item))
                {
                    yielding = true;
                }
                if (yielding)
                {
                    yield return item;
                }
            }
        }

        public static T MaxBy<T, TKey>(IEnumerable<T> source, Func<T, TKey> selector) where TKey : IComparable<TKey>
        {
            return source.OrderByDescending(selector).FirstOrDefault();
        }

        public static T MinBy<T, TKey>(IEnumerable<T> source, Func<T, TKey> selector) where TKey : IComparable<TKey>
        {
            return source.OrderBy(selector).FirstOrDefault();
        }
        
        public static IEnumerable<int> GenerateRange(int start, int count)
        {
            return Enumerable.Range(start, count);
        }

        public static DateTime Tomorrow()
        {
            return DateTime.Today.AddDays(1);
        }

        public static DateTime Yesterday()
        {
            return DateTime.Today.AddDays(-1);
        }

        public static bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        public static string Format(this DateTime date, string format)
        {
            return date.ToString(format);
        }

        
        [CanBeNull]
        public static T FirstOrNull<T>(this IEnumerable<T> source) where T : class
        {
            return source.FirstOrDefault();
        }

        [CanBeNull]
        public static T LastOrNull<T>(this IEnumerable<T> source) where T : class
        {
            return source.LastOrDefault();
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            Random rand = new Random();
            T[] elements = source.ToArray();
            for (int i = elements.Length - 1; i > 0; i--)
            {
                int swapIndex = rand.Next(i + 1);
                (elements[i], elements[swapIndex]) = (elements[swapIndex], elements[i]);
            }
            return elements;
        }

        public static void ExecuteSafe(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                // ログ記録や例外処理
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }

        public static T ExecuteWithResultSafe<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                // ログ記録や例外処理
                Console.WriteLine("Exception caught: " + ex.Message);
                return default;
            }
        }

        public static void Deconstruct<T>(this IList<T> list, out T first, out IList<T> rest)
        {
            first = list.Count > 0 ? list[0] : default;
            rest = list.Skip(1).ToList();
        }

        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey Key, TValue Value)> tuples)
        {
            return tuples.ToDictionary(t => t.Key, t => t.Value);
        }

        [CanBeNull]
        public static T Find<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : class
        {
            return source.FirstOrDefault(predicate);
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Where(predicate);
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Where(predicate).Any();
        }
    
        public static bool None<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return !source.Any(predicate);
        }

        [CanBeNull]
        public static T FirstOrNull<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : class
        {
            return source.FirstOrDefault(predicate);
        }

        [CanBeNull]
        public static T SingleOrNull<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : class
        {
            try
            {
                return source.SingleOrDefault(predicate);
            }
            catch
            {
                return null;
            }
        }

        [CanBeNull]
        public static T ElementAtOrNull<T>(this IEnumerable<T> source, int index) where T : class
        {
            var enumerable = source.ToList();
            if (enumerable.Count > index)
            {
                return enumerable.ElementAt(index);
            }
            return null;
        }

        [CanBeNull]
        public static T FindLast<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : class
        {
            return source.LastOrDefault(predicate);
        }

        public static int FindIndex<T>(this IList<T> list, Func<T, bool> predicate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FindLastIndex<T>(this IList<T> list, Func<T, bool> predicate)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (predicate(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }

    }
    
}