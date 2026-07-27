using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

//タイマーの制御と表示
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] float RemainingTime;

   

    public string Scene_Name;//シーン読み込み
    // Update is called once per frame
    void Update()
    {
        //残り時間が0かそれ以外か
        if (RemainingTime > 0)
        {
            //時間を引いていくのは-＝
            //時間を足していくのは+＝
            if (RemainingTime >= 0)
            {
                RemainingTime -= Time.deltaTime;
            }
               
        }
        //残り時間が0になると引くことを止めて文字を黄色に変える
        else if (RemainingTime <= 0)
            {
            RemainingTime = 0;
            //GameOvere();
            TimerText.color = Color.yellow;
            Debug.Log("ゲーム終了");
            PlayerPrefs.SetInt("Score", Score_Manager.score_num);
            SceneManager.LoadScene(Scene_Name);
        }
        //計算
        //60で割る
        int Minutes = Mathf.FloorToInt(RemainingTime / 60);
        int Seconds = Mathf.FloorToInt(RemainingTime % 60);
        // テキストの表示
        TimerText.text = string.Format("{0:00}:{1:00}", Minutes, Seconds);
    }
}
