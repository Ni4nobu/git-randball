using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class OBJ_Drete : MonoBehaviour
{
    GameObject player;

    public float distance = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

       
        if (player != null)
        {
            //float x = player.transform.position.x + 20;
            //float y = -10 ;
            //float z = 0 ;
            float x = player.transform.position.x + 5;
            float y = -2;
            float z = 0;

            
            Vector3 v3 = new Vector3(x, y, z);
            transform.localPosition = v3;
        }
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * 5 * Time.deltaTime;
        }

        if (Input.GetKey("down"))
        {
            transform.position += transform.forward * -5 * Time.deltaTime;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score"))
        {
            Destroy(other.gameObject);
        }
    }
}
