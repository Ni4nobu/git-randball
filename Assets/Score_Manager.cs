using TMPro;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{

    [SerializeField] float RemainingScore;
    [SerializeField] TextMeshProUGUI Score_Text;// Textオブジェクト
    // Update is called once per frame
    void Update()
    {
        int score_num = Mathf.FloorToInt(RemainingScore + 0); // スコア変数 
        score_num += 2; // とりあえず1加算し続けてみる
        // テキストの表示を入れ替える
        Score_Text.text = string.Format ("Score:000000{0}" , score_num);
         
    }
}
