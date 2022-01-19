// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;

// using System.Text.RegularExpressions;
// using Wox.Plugin;
namespace Community.PowerToys.Run.Plugin.Dictionary
{
    public class InputInterpreter
    {
        private readonly Dictionary<string, string> dictionary;

        public InputInterpreter()
        {
            this.dictionary = new Dictionary<string, string>()
                {
                    { "Author", "voruti" },
                    { "Name", "Dictionary" },
                };
        }

        public List<DictionarySearchResult> QueryDictionary(string str)
        {
            // str = Regex.Replace(str, @":$", string.Empty);
            return dictionary.Keys
                .ToList()
                .FindAll(stringKey => stringKey.ToLower().StartsWith(str.ToLower()))
                .OrderBy(stringKey => (stringKey.Length - str.Length).ToString("D4") + dictionary.GetValueOrDefault(stringKey))
                .Select(stringKey => new DictionarySearchResult(stringKey, dictionary.GetValueOrDefault(stringKey), (int)Math.Round(((double)str.Length / stringKey.Length) * 200)))
                .ToList();
        }

        /*public static List<DictionarySearchResult> Parse(Query query)
        {
            List<string> splitList = query.Search.Split(' ').ToList();

            return splitList
                .SelectMany(QueryDictionary)
                .Distinct()
                .ToList();
        }*/
    }
}
