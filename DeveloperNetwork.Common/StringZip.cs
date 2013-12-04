using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperNetwork.Common {

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <para>Digiwin.Mars.VirtualUI~Digiwin.Mars.VirtualUI.VirtualObjectTypeAttribute.html</para>
    /// <para>Digiwin.Mars.VirtualUI~Digiwin.Mars.VirtualUI.VirtualObjectTypeAttribute_members.html</para>
    /// </remarks>
    public sealed class StringZip {
        private Dictionary<string, int> _wordDict;
        private List<string> _wordIndexs;
        //用于分割的字符
        private static Dictionary<char,string> _splitChars;

        static StringZip() {
            var splitChars = new HashSet<char>() {
                ',',
                '.',
                ' ',
                '(',
                ')',
                '<',
                '>',
                '~',
                '@',
                '_',
                '-',
                '/',
                '\\',
                '，',
                '。',
                '“',
                '”'
            };

            _splitChars = new Dictionary<char, string>(splitChars.Count);
            foreach (var c in splitChars) {
                _splitChars.Add(c, new string(new char[] { c }));
            }
        }

        /// <summary>
        /// 创建唯一的实例，此实例不支持并发。
        /// </summary>
        public StringZip() {
            this._wordDict = new Dictionary<string, int>();
            this._wordIndexs = new List<string>();
        }

        /// <summary>
        /// 根据数据返回对应的字符串。
        /// </summary>
        /// <param name="zipData">压缩的数据</param>
        /// <returns>字符串结果。</returns>
        public string UnzipString(int[] zipData) {
            if (zipData == null) {
                return null;
            }

            if (zipData.Length == 0) {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var index in zipData) {
                sb.Append(this.GetWord(index));
            }
            return sb.ToString();
        }

        private static int[] EmptyData = new int[0];
        /// <summary>
        /// 压缩字符串。
        /// </summary>
        /// <param name="words">要压缩的字符串</param>
        /// <returns>一组数据</returns>
        public int[] ZipString(string words) {
            if (words == null) {
                return null;
            }
            if (words.Length == 0) {
                return EmptyData;
            }

            var charCount = words.Length;
            List<int> indexs = new List<int>(charCount / 4);
            char[] wordCache = new char[charCount];
            int cacheCount = 0;
            string word;
            string splitWord;

            foreach (var c in words) {
                wordCache[cacheCount] = c;
                //需要分割
                if (_splitChars.TryGetValue(c, out splitWord)) {
                    if (cacheCount > 0) {
                        //获取前面的单词
                        word = new string(wordCache, 0, cacheCount);
                        indexs.Add(this.GetOrAddWord(word));
                    }

                    //当前分隔符也要存入
                    indexs.Add(this.GetOrAddWord(splitWord));

                    cacheCount = 0;
                }
                else {
                    cacheCount++;
                }
            }

            if (cacheCount > 0) {
                //获取前面的单词
                word = new string(wordCache, 0, cacheCount);
                indexs.Add(this.GetOrAddWord(word));
            }

            return indexs.ToArray();
        }


        /// <summary>
        /// 返回指定索引的单词，如果未找到单词将返回null.
        /// </summary>
        /// <param name="index">要查询的单词索引</param>
        /// <returns>如果此索引登记过返回其对应的单词，否则返回null.</returns>
        public string GetWord(int index) {
            if (index < 0 || index >= this._wordIndexs.Count) {
                return null;
            }
            return this._wordIndexs[index];
        }

        /// <summary>
        /// 强制添加一个单词到字典中，返回可能的索引。
        /// </summary>
        /// <param name="word">要添加的单词索引</param>
        /// <returns>返回此单词的索引，如果未添加过会创建索引并返回。</returns>
        public int GetOrAddWord(string word) {
            if (word == null) {
                return -1;
            }

            int index;
            if (this._wordDict.TryGetValue(word,out index)) {
                return index;
            }

            index = this._wordIndexs.Count;
            this._wordDict.Add(word, index);
            this._wordIndexs.Add(word);
            return index;
        }
    }
}
