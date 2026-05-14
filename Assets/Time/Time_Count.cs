using UnityEngine;

public class Time_Count : MonoBehaviour
{
    public bool isCountDoun = true;
    public bool isTimeOver = false;
    public float gameTime = 0;
    public float displayTime = 0;

    float times = 0;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(isCountDoun)
        {
            displayTime = gameTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimeOver == false)
        {
            times += Time.deltaTime;
            if(isCountDoun)
            {
                displayTime = gameTime -times ;
                if(displayTime <= 0.0f)
                {
                    displayTime = 0.0f ;
                    isTimeOver = true ;
                }
            }
            else
            {
                displayTime = times ;
                if(displayTime >= gameTime)
                {
                    displayTime = gameTime;
                    isTimeOver=true ;
                }
                Debug.Log("TIMES:" + displayTime);
            }
        }
    }
}
