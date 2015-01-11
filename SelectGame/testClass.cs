using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelectGame
{
    /// <summary>
    /// クラス化するためのテストクラス
    /// 難しいこと考えてたんだけどこれでいいんじゃね？的な
    /// Accmotionから知識を流用
    /// 便宜的に文字だけをはじき出すようにしてみるとか
    /// ゆかりさん愛してる
    /// </summary>
    class testClass
    {
        static string[] text = new string[] { Properties.Resources.ques1 , Properties.Resources.good, Properties.Resources.bad };
        ///
        /// ~10問題
        /// ~30表示文
        /// ~100取りあえず作っただけ
        ///

        public static string get_ques()
        {
            return text[0];
        }

        public static string get_good()
        {
            return text[1];
        }

        public static string get_bad()
        {
            return text[2];
        }


    }
}
