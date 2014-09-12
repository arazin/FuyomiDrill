using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FuyomiDrillCore
{
    /// <summary>
    /// QuestionSetは各問の情報を表す構造体です。
    /// </summary>
    public struct QuestionSet
    {

        private int octave;
        private string ans;
        private string question;


        /// <summary>
        /// Octaveプロパティは、正解の音のオクターブ位置を表します。
        /// </summary>
        public int Octave
        {
            set { this.octave = value; }
            get { return this.octave; }
        }

        /// <summary>
        /// Ansプロパティは、正解の音名を表します。
        /// </summary>
        public string Ans
        {
            set { this.ans = value; }
            get { return this.ans; }
        }

        /// <summary>
        /// Questionプロパティは、問題文を表します。
        /// 文字列は使用する五線譜フォントに対応する必要があります。
        /// </summary>
        public string Question
        {
            set { this.question = value; }
            get { return this.question; }
        }

    }

    /// <summary>
    /// FuyomiDrillのロジックの実装です。
    /// </summary>
    public class FuyomiGame
    {
        /// <summary>
        /// 問題一覧を記述したテキストファイルへのパス
        /// </summary>
        private string path;
        /// <summary>
        /// 問題レベル
        /// </summary>
        private int level;
        /// <summary>
        /// 全問題を格納するlist
        /// </summary>
        private List<QuestionSet> drill;
        /// <summary>
        /// このゲームでこなした問題の数
        /// </summary>
        private int qCount;
        /// <summary>
        /// 問題リストのインデックス
        /// </summary>
        private int qIndex;
        /// <summary>
        /// ゲームでこなす問題の数
        /// </summary>
        private const int qMax = 30;



        /// <summary>
        /// FuyomiGameのコンストラクタ
        /// </summary>
        /// <param name="level">問題のレベル</param>
        public FuyomiGame(int level)
        {
            drill = new List<QuestionSet>();
            path = @"..\..\" + level.ToString() + ".txt";
            this.level = level;

            if (File.Exists(path))
            {
                qSetRead();
                qSetShuffle();
            }
            else
            {
                throw new FileNotFoundException(path + " Not Found.");
            }


        }

        /// <summary>
        /// 問題セットのシャッフル
        /// </summary>
        private void qSetShuffle()
        {
            System.Random rng = new System.Random();
            int n = drill.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                QuestionSet tmp = drill[k];
                drill[k] = drill[n];
                drill[n] = tmp;
            }
        }

        /// <summary>
        /// pathのテキストから問題を読み取りlistへ格納
        /// テキストの形式は一問一行で Octave,Ans,Questionのcsv
        /// </summary>
        private void qSetRead()
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string tmp = "";
                while ((tmp = sr.ReadLine()) != null)
                {
                    QuestionSet qSet = new QuestionSet();
                    string[] split = tmp.Split(',');
                    qSet.Octave = Convert.ToInt32(split[0]);
                    qSet.Ans = split[1];
                    qSet.Question = "=" + split[2];
                    drill.Add(qSet);
                }
            }
        }

        /// <summary>
        /// ゲームを開始し、始めの問題を返す
        /// </summary>
        /// <returns>五線譜フォントに対応した、問題の文字列</returns>
        public string GameStart()
        {
            return drill[0].Question;
        }

        // TODO : 解答に対する応答.未実装
        public string IsCorrect(string ans)
        {
            throw new NotImplementedException();
        }

    }
}
