using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Manager : MonoBehaviour
{
    public GameObject StartButton;//スタートボタン
    public GameObject GameEndBotton;//ゲーム終了ボタン

    public string Scene_Name;//シーン読み込み
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(Scene_Name);
        }
    }
    //スタートボタン押した
    public void StartButtonClicked()
    {
        SceneManager.LoadScene(Scene_Name);
    }
    //ゲーム終了ボタン押した
    public void GameEndBottonClicked()
    {
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
