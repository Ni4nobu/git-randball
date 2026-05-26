using UnityEngine;

public class Menu : MonoBehaviour
{
    bool Menu_Push = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Menu_Push == false)
            {
                PauseGame();
            }
            else if (Menu_Push == true)
            {
                ResumeGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        Menu_Push = true;
        Debug.Log("ポーズ");
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Menu_Push = false;
        Debug.Log("ポーズ解除");
    }
}
