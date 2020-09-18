using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbreviations
{
    class Program
    {
        static void Main(string[] args)
        {

            // コンストラクタ呼び出し
            var abbrs = new Abbreviaition();

            // Add呼び出し
            abbrs.Add("IOC", "国際オリンピック委員会");

            // インデクサ利用
            var names = new[] { "WHO", "FIFA", "NPT", };
            foreach(var name in names)
            {
                var fullname = abbrs[name];
                if(fullname == null)
                {
                    Console.WriteLine("{0}は見つかりません", name);
                }
                else
                {
                    Console.WriteLine("{0}={1}", name, fullname);
                }
            }

            Console.ReadKey();
        }
    }
}
