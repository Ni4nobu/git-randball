using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//リザルト画面のシーン移動とボタンとマウスの制御を行う
public class Clear_Manager : MonoBehaviour
{
    public GameObject GameButton;//スタートボタン
    public GameObject GameEndBotton;//ゲーム終了ボタン
    public GameObject GameTitleBotton;//タイトルボタン

    public string Scene_Name;//シーン読み込み
    public string Scene_Name_Title;//シーン読み込み
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Cursor.lockState = CursorLockMode.Confined; //マウスカーソルの移動をゲームウィンドウ内に制限
        Cursor.visible = true;//カーソル表示
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーでゲームに戻る
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(Scene_Name);
        }
        if (Input.GetKey(KeyCode.Return))
        {
            //タイトルに行く
            SceneManager.LoadScene(Scene_Name_Title);
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
    public void GameButtonClicked()
    {
        //ゲームに行く
        SceneManager.LoadScene(Scene_Name);
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
        SceneManager.LoadScene(Scene_Name_Title);
    }
}
