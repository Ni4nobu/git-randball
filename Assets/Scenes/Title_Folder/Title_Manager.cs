using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
//タイトル画面の制御
public class Title_Manager : MonoBehaviour
{
    public GameObject StartButton;//スタートボタン
    public GameObject GameEndBotton;//ゲーム終了ボタン

    private AudioSource audioSource = null;
    public AudioClip SE;

    public string Scene_Name;//シーン読み込み
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; //マウスカーソルの移動をゲームウィンドウ内に制限
        Cursor.visible = true;//カーソル表示

        Screen.SetResolution(1920, 1080, true);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーでゲームに行く
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //PlaySE(SE);
            StartCoroutine(PrintHello());
            // SceneManager.LoadScene(Scene_Name);
        }
        if (Input.GetKeyDown(KeyCode.Return))
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
    //スタートボタン押した
    public void StartButtonClicked()
    {
        //PlaySE(SE);
        //yield return
        //new WaitForSeconds(3.0f);
        //new WaitForSeconds(3.0f);
        //new WaitForSeconds(3.0f);
        
        //ゲームに行く
        //SceneManager.LoadScene(Scene_Name);
        StartCoroutine(PrintHello());
    }
    IEnumerator PrintHello()
    {
        PlaySE(SE);
        yield return new WaitForSeconds(0.8f); // 3秒待機
        SceneManager.LoadScene(Scene_Name);
    }

    //ゲーム終了ボタン押した
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
    public void LoadScene()
    {
       
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
