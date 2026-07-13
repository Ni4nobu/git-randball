using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_Sound : MonoBehaviour
{
    public string Scene_Name_Titre;//シーン読み込み
    public string Scene_Name_Game;//シーン読み込み
    public string Scene_Name_Clear;//シーン読み込み

    public AudioSource Titre_BGM;
    public AudioSource Game_BGM;
    public AudioSource Clear_BGM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Start");
        string Scene_Name = SceneManager.GetActiveScene().name;
        if (Scene_Name == Scene_Name_Titre)
        {
            Debug.Log("タイトル");
            Clear_BGM.Stop();
            Game_BGM.Stop();
            Titre_BGM.Stop();

            Titre_BGM.Play();
        }
        if (Scene_Name == Scene_Name_Game)
        {
            Debug.Log("ゲーム");
            Clear_BGM.Stop();
            Game_BGM.Stop();
            Titre_BGM.Stop();

            Game_BGM.Play();
        }
        if (Scene_Name == Scene_Name_Clear)
        {
            Debug.Log("リザルト");
            Clear_BGM.Stop();
            Game_BGM.Stop();
            Titre_BGM.Stop();

            Clear_BGM.Play();
        }
    
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }
}
