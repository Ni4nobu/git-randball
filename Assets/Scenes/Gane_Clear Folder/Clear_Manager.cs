using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

//リザルト画面のシーン移動とボタンとマウスの制御を行う
public class Clear_Manager : MonoBehaviour
{
    public GameObject GameButton;//スタートボタン
    public GameObject GameEndBotton;//ゲーム終了ボタン
    public GameObject GameTitleBotton;//タイトルボタン

    public string Scene_Name;//シーン読み込み
    public string Scene_Name_Title;//シーン読み込み

    private AudioSource audioSource = null;
    public AudioClip SE;
    public AudioClip SE_Score_Start;
    public AudioClip SE_Score_Stop;
    [SerializeField] TextMeshProUGUI Score_Text;
    [SerializeField] TextMeshProUGUI Best_Text;

    bool isCountUp = false;
    int Display_Score = 0;
    int score = 0;
    int Best_score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Cursor.lockState = CursorLockMode.Confined; //マウスカーソルの移動をゲームウィンドウ内に制限
        Cursor.visible = true;//カーソル表示
        audioSource = GetComponent<AudioSource>();
        score = PlayerPrefs.GetInt("Score", 100);
        Best_score = PlayerPrefs.GetInt("Best_Score", Best_score);
        isCountUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountUp == true)
        {
            //PlaySE(SE_Score_Start);
            int digit = score.ToString().Length;
            if (digit > 0)
            {
                if (digit == 1|| digit == 2 || digit == 3)
                {
                    Display_Score++;
                }
                else if(digit == 4)
                {
                    Display_Score += 2;
                }
                else if (digit == 5)
                {
                    Display_Score += 20;
                }
                else 
                {
                    Display_Score += 100;
                }
            }

            if (Display_Score >= score)
            {
                PlaySE(SE_Score_Stop);
                //カウントアップ終了
                Display_Score = score;
                isCountUp = false;
            }
            Score_Text.text = string.Format("{0:0000000}", Display_Score);
            if (score > Best_score)
            {
                Best_score = score;
                PlayerPrefs.SetInt("Best_Score", Best_score);

            }
            Best_Text.text = string.Format("{0:0000000}", Best_score);
        }
        //スペースキーでゲームに戻る
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Scene_Game());
            //SceneManager.LoadScene(Scene_Name);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //タイトルに行く
            StartCoroutine(Scene_Title());
            //SceneManager.LoadScene(Scene_Name_Title);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ゲーム終了
#if UNITY_EDITOR
            // Unityエディターでの動作
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // 実際のゲーム終了処理
        Application.Quit();
#endif
        }

    }
    IEnumerator Scene_Title()
    {
        PlaySE(SE);
        yield return new WaitForSeconds(0.8f); // 3秒待機
        SceneManager.LoadScene(Scene_Name_Title);
    }
    IEnumerator Scene_Game()
    {
        PlaySE(SE);
        yield return new WaitForSeconds(0.8f); // 3秒待機
        SceneManager.LoadScene(Scene_Name);
    }
    //スタートボタン押した
    public void GameButtonClicked()
    {
        //ゲームに行く
        StartCoroutine(Scene_Game());
        //SceneManager.LoadScene(Scene_Name);
    }
    public void GameEndBottonClicked()
    {
        //ゲーム終了
#if UNITY_EDITOR
        // Unityエディターでの動作
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 実際のゲーム終了処理
        Application.Quit();
#endif
    }
    public void GameTitleBottonClicked()
    {
        //タイトルに行く
        StartCoroutine(Scene_Title());
        //SceneManager.LoadScene(Scene_Name_Title);
    }
    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }
}
