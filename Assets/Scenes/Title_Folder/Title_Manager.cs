using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//タイトル画面の制御
public class Title_Manager : MonoBehaviour
{
    public GameObject StartButton;//スタートボタン
    public GameObject GameEndBotton;//ゲーム終了ボタン

    public string Scene_Name;//シーン読み込み
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; //マウスカーソルの移動をゲームウィンドウ内に制限
        Cursor.visible = true;//カーソル表示

        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーでゲームに行く
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(Scene_Name);
        }
        if (Input.GetKey(KeyCode.Return))
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
        if (Input.GetKey(KeyCode.Escape))
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
        //ゲームに行く
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
}
