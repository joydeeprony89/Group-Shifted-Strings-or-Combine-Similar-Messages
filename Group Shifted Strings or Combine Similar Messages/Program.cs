using System;
using System.Collections.Generic;
using System.Text;

namespace Group_Shifted_Strings_or_Combine_Similar_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = new string[] { "abc", "bcd", "acef", "xyz", "az", "ba", "a", "z" };
            var results = GroupStrings(strings);
            foreach(var result in results)
                Console.WriteLine(string.Join(",", result));
        }


        static IList<IList<string>> GroupStrings(string[] strings)
        {
            Dictionary<string, List<string>> hash = new Dictionary<string, List<string>>();
            List<IList<string>> result = new List<IList<string>>();
            foreach(string str in strings)
            {
                string key = GetKey(str);
                if (hash.ContainsKey(key))
                {
                    var existing = hash[key];
                    existing.Add(str);
                    hash[key] = existing;
                }
                else
                {
                    hash.Add(key, new List<string>() { str });
                }
            }
            foreach (var values in hash.Values)
                result.Add(values);

            //result.AddRange(hash.Values); // AddRange() has lower performance when working with large sets of data.
            return result;
        }

        private static string GetKey(string str)
        {
            StringBuilder key = new StringBuilder("1");
            if (str.Length == 1) return key.ToString();
            for(int i = 1; i < str.Length; i++)
            {
                var difference = str[i] - str[i - 1];
                key.Append(difference < 0 ? difference + 26 : difference);
                key.Append(",");
            }

            return key.ToString();
        }
    }
}
