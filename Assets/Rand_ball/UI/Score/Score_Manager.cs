using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//スコアの表示を行っている
public class Score_Manager : MonoBehaviour
{
   // private readonly int score;
    [SerializeField] float RemainingScore;
    [SerializeField] TextMeshProUGUI Score_Text;// Textオブジェクト

    
    // Update is called once per frame
    void Update()
    {
        int score_num = Mathf.FloorToInt(RemainingScore + 0); // スコア変数 
        score_num += Ball_Mobe.instance.sentence; // スコアを足す
        //score_num += OBJ_HP.instance.sentence; // スコアを足す
        //score_num += OBJ_Management.instance.sentence; // スコアを足す

        score_num += Bomb.instance.sentence; // スコアを足す

        // Debug.Log(Ball_Mobe.instance.sentence);
        // テキストの表示を入れ替える
        Score_Text.text = string.Format ("Score:{0000000}" , score_num);//スコアの表示
         
    }

}
