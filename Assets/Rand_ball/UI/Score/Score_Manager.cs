using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;


//スコアの表示を行っている
public class Score_Manager : MonoBehaviour
{
   // private readonly int score;
    [SerializeField] float RemainingScore;
    //スコアを表示するText
    [SerializeField] TextMeshProUGUI Score_Text;// Textオブジェクト

    //スコア合計
    public static int score_num = 0;
    //表示用のスコア
    int Display_Score = 0;
   // int Display_Score_Max = 0;
    //スコア
    int Score = 0;
    int Digit_Score = 0;
    //カウントアップ中かどうか
    bool isCountUp = false;


    public static Score_Manager instance;
    public int sentence;

    // Score_Text.text = string.Format("{0:0000000}", score);



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score_num = 0;
        Score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        //score_num = Mathf.FloorToInt(RemainingScore + 0); // スコア変数 

        //score_num += Ball_Mobe.instance.sentence; // スコアを足す
        //score_num += Bomb.instance.sentence; // スコアを足す

       
        

        if (Score == 0)
        {
            Score += Ball_Mobe.instance.sentence; // スコアを足す
            Score += Bomb.instance.sentence; // スコアを足す
        }
        Ball_Mobe.instance.sentence = 0;
        Bomb.instance.sentence = 0;

        //Score_Text.text = string.Format("{0:000000}", score_num);//スコアの表示
        if (Score > 0)
        {
            score_num += Score;
           // Digit_Score = Mathf.Max(Digit_Score, Score);
            Digit_Score = Score;
            Score_Manager.instance.sentence += Score;
            Score = 0;
            isCountUp = true;
        }
        //if (Display_Score <= score_num)
        //{
        //    //Debug.Log("スコア中身" + score_num);
        //    //カウントアップ
        //    isCountUp = true;
        //}
        //カウントアップのアニメーション中であれば
        if (isCountUp == true)
        {
            //桁数を見る
            int a = score_num - Display_Score;
            int digit = a.ToString().Length;
            // Debug.Log(digit+"桁");
            if (digit == 1|| digit == 2 )
            {
                Display_Score += 1;
            }
            else if (digit == 3)
            {
                Display_Score += 3;
            }
            else if (digit == 4)
            {
                Display_Score += 10;
            }
            else
            {
                Display_Score += 100;
            }
            //else if ((score_num - Display_Score) >= 10000)
            //{
            //    Display_Score += 4;
            //}
            //表示スコアがスコアを超えれば
            if (Display_Score >= score_num)
            {
                //カウントアップ終了
                Display_Score = score_num;
                isCountUp = false;
                // Digit_Score = 0;
                //Display_Score_Max += Display_Score;
            }

            //スコア表示を更新する
            Score_Text.text = string.Format("{0:0000000}", Display_Score);//スコアの表示
            //Score_Text.text = string.Format("+{0}", Display_Score);//スコアの表示
        }

    }
    void Awake()
    {
        // インスタンスがまだ作られていなければ自分を代入
        if (instance == null)
        {
            instance = this;
        }
        score_num = 0;
        Display_Score = 0;
        Score = 0;
        sentence = 0;
    }
}
