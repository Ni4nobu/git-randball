using UnityEngine;

public class Ball_Chase : MonoBehaviour
{
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float frontLimit = 0.0f;
    public float backLimit = 0.0f;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");
        if (player != null )
        {
            float x = player.transform.position.x + 3;
            float y = player.transform.position.y + 2;
            float z = player.transform.position.z ;

            Vector3 v3 = new Vector3(x, y, z);
            transform.localPosition = v3;
      
        }
        
    }
}
