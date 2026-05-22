using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear_Manager : MonoBehaviour
{
    public GameObject GameButton;//スタートボタン
    //public GameObject GameEndBotton;//ゲーム終了ボタン

    public string Scene_Name;//シーン読み込み
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; //マウスカーソルの移動をゲームウィンドウ内に制限
        Cursor.visible = true;//カーソル表示
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
    public void GameButtonClicked()
    {
        SceneManager.LoadScene(Scene_Name);
    }
    
}
