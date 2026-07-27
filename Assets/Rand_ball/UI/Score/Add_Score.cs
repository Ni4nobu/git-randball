using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class Add_Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Add_Score_Text;// Textオブジェクト
    [SerializeField] CanvasGroup group;

    //スコア
    int Score = 0;
    int Check_Score = 0;

    //表示する時間
    private float Display_Time = 0.09f;
    private float time = 0.0f;
    bool Time_Anime = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0;
        Display_Time = 1.0f;
        time = 0.0f;
        group.alpha = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        Score += Score_Manager.instance.sentence; // スコアを足す
        Score_Manager.instance.sentence = 0;
        // Ball_Mobe.instance.sentence = 0;

        //Score += Bomb.instance.sentence; // スコアを足す
        // Bomb.instance.sentence = 0;
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    //押した
        //    Score = 100;

        //    // Dash_Time = 1.0f;
        //}
        if (Score > 0)
        {

            Check_Score = Score;
            Add_Score_Text.text = string.Format("+{0}", Check_Score);//スコアの表示
            group.alpha = 1;
            Time_Anime = true;
            time = 0.0f;
            Score = 0;
            
        }
        if(Time_Anime == true)
        {
            //group.alpha = 0.9f;
            time += Time.deltaTime;
            
                if (time >= Display_Time)
            {
                group.alpha -= 2.0f* Time.deltaTime;
               
                if (group.alpha < 0)
                {
                    group.alpha = 0;
                    Time_Anime = false;
                }
               
                
            }
        }
        if (Time_Anime == false)
        {
            group.alpha = 0;
        }
    }
    
}
