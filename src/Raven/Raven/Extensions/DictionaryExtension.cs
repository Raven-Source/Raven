using System.Collections.Generic;

namespace Raven.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static bool IsEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dict)
        {
            return dict == null || dict.Count == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            TValue value = default(TValue);
            if (dict.TryGetValue(key, out value))
            {
                return value;
            }
            else
            {
                return default(TValue);
            }
        }

    }
}
