using UnityEngine;
using UnityEngine.UI;

public class Button_Selected : MonoBehaviour
{
    //現状使用していない
    //Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    private Image image;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // 色を指定
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            //image.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            Getcomponent<Image>.color = new Color32(242, 108, 216, 255);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //image.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
           // image.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //image.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }

    }
}

internal class Getcomponent<T>
{
    internal static Color32 color;
}