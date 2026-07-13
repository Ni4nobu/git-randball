using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Cursor.lockState = CursorLockMode.Confined; //マウスカーソルの移動をゲームウィンドウ内に制限
        Cursor.visible = true;//カーソル表示
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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
