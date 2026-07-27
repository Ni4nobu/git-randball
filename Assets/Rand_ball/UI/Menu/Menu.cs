using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Menu_Text;// Textオブジェクト
    [SerializeField] CanvasGroup Menu_group;



    //スタートカウント
    [SerializeField] TextMeshProUGUI Start_Text;// Textオブジェクト
    [SerializeField] CanvasGroup Start_group;

    public bool Start_Go_on = false;
   
    public bool Count = false;
    public bool Count_on = false;
    public bool Start_timer_on = false;//スタートカウントが使用中か
    public float timer = 3;
    public int Drawing_Count;

    //カウントダウンSE
    public bool Start_Sound_on1 = false;
    public bool Start_Sound_on2 = false;
    public bool Start_Sound_on3 = false;

    public AudioClip SE_Count1;
    //public AudioClip SE_Count2;
    //public AudioClip SE_Count3;
    public AudioClip SE_CountGO;

    public GameObject Menu_Button;//メニューボタン

    private AudioSource audioSource = null;
    public AudioClip SE_Start;

    public AudioClip SE_End;

    public AudioClip SE_Select;

    public string Scene_Name;//シーン読み込み
    public string Scene_Name_ReStart;//シーン読み込み

    bool Menu_Push = false;
    //bool Controll_Screen_Push = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Start_Go_on = true;
        Start_timer_on = true;
        Count_on = true;
        Time.timeScale = 0;
        Count = false;
        timer = 3;
        
        Start_Sound_on3 = true;
        Start_Sound_on2 = true;
        Start_Sound_on1 = true;

        Start_group.alpha = 1;
        
        Menu_group.alpha = 0;


        audioSource = GetComponent<AudioSource>();
        Menu_Push = false;

    }


    // Update is called once per frame
    void Update()
    {
        if (Count == true && Menu_Push == false && Start_timer_on == true)
        {
            //スタートタイム終了
            Start_group.alpha = 0;
            Time.timeScale = 1;
            
            Count_on = false;
            Count = false;
            Start_timer_on = false;
        }
        Time_Count();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameMenu_Push();
        }
    }
    public void Time_Count()
    {
        if(Menu_Push == false && Start_timer_on == true)//メニューを開いてるときは時間を止める
        {
            timer -= Time.unscaledDeltaTime;
            if (timer <= 0)
            {
                //Start_Go_on = true;

                if (Start_Go_on == true)
                {
                    StartCoroutine(Count_Start_on());
                    Start_Go_on = false;
                }
                timer = 0;

            }
            else 
            {
                Drawing_Count = Mathf.CeilToInt(timer);
                if (Drawing_Count == 3 && Start_Sound_on3 == true)
                {
                    PlaySE(SE_Count1);
                    Start_Sound_on3 = false;

                }
                if (Drawing_Count == 2 && Start_Sound_on2 == true)
                {
                    PlaySE(SE_Count1);
                    Start_Sound_on2 = false;
                    
                }
                if (Drawing_Count == 1 && Start_Sound_on1 == true)
                {
                    PlaySE(SE_Count1);
                    Start_Sound_on1 = false;

                }
                Start_Text.text = string.Format("{0:0}", Drawing_Count);//表示
                
            }
            
        }
        

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        Menu_Push = true;
        Debug.Log("ポーズ");
        EventSystem.current.SetSelectedGameObject(null); 

        Cursor.lockState = CursorLockMode.Confined; //マウスカーソルの移動をゲームウィンドウ内に制限
        Cursor.visible = true;//カーソル表示
        Menu_group.alpha = 1;
    }
    public void ResumeGame()
    {
        if (Count_on == false)
        {
            Time.timeScale = 1;
        }
        
        Menu_Push = false;
        Debug.Log("ポーズ解除");
        Cursor.lockState = CursorLockMode.Locked;//カーソルを動かしても画面から出ない
        Cursor.visible = false;//カーソルを非表示

       
        Menu_group.alpha = 0;
    }
    
    public void GameMenuBottonClicked()
    {
       // GameMenu_Push();
        if (Menu_Push == true)//メニュー閉じる
        {
            ResumeGame();
            PlaySE(SE_End);
        }
    }
    public void GameMenu_Push()
    {
        if (Menu_Push == false)//メニュー開く
        {
            PauseGame();
            PlaySE(SE_Start);
        }
        else if (Menu_Push == true )//メニュー閉じる
        {
            ResumeGame();
            PlaySE(SE_End);
        }
    }
    public void GameMenu_Title_BottonClicked()//タイトルボタン
    {
        //PlaySE(SE_Start);
        StartCoroutine(PrintHello());
    }
    
    public void GameMenu_Start_BottonClicked()//リスタートボタン
    {
       // PlaySE(SE_Start);
        StartCoroutine(Start_Re());
    }
    
    public void GameMenu_Controll_BottonClicked()//遊び方ボタン
    {
        PlaySE(SE_Select);
       
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator PrintHello()
    {
        PlaySE(SE_Select);
        yield return new WaitForSecondsRealtime(0.8f); // 3秒待機
        SceneManager.LoadScene(Scene_Name);
        Time.timeScale = 1;
    }
    IEnumerator Start_Re()
    {
        PlaySE(SE_Select);
        yield return new WaitForSecondsRealtime(0.8f); // 3秒待機
                                                       // SceneManager.LoadScene(Scene_Name);
        Time.timeScale = 1;
        ResetScene();
    }
    IEnumerator Count_Start_on()
    {
        
        PlaySE(SE_CountGO);
           
        Start_Text.text = string.Format("START");//表示
       
        yield return new WaitForSecondsRealtime(0.6f); // 待機

        Count = true;
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
