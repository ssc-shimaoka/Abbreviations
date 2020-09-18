using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbreviations
{
    // 略語と対応する日本語を管理するクラス
    class Abbreviaition
    {
        // 内部ディクショナリ
        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        // コンストラクタ
        public Abbreviaition()
        {
            var lines = File.ReadAllLines("Abbreviations.txt");

            _dict = lines.Select(line => line.Split('='))
                .ToDictionary(x => x[0], x => x[1]);
        }

        // 要素追加
        public void Add(string abbr, string japanese)
        {
            _dict[abbr] = japanese;
        }

        // インデクサ
        public string this[string abbr]
        {
            get
            {
                return _dict.ContainsKey(abbr) ? _dict[abbr] : null;
            }
        }


        // 日本語から対応する省略語を取り出す
        public string ToAbbreviation(string japanese)
        {
            return _dict.FirstOrDefault(x => x.Value == japanese).Key;
        }


        // 日本語 の 位置 を 引数 に 与え、 それ が 含ま れる 要素（ Key、 Value） を すべて 取り出す
        public IEnumerable<KeyValuePair<string, string>> FindAll(string substring)
        {
            foreach(var item in _dict)
            {
                if(item.Value.Contains(substring))
                {
                    yield return item;
                }
            }
        }
    }
}
