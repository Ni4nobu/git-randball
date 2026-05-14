using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class NewMonoBehaviourScript : MonoBehaviour
{
    
    Rigidbody rb;
    //入力
    float posX = 0.0f;
    float posY = 0.0f;
    float posZ = 0.0f;
    float ball_speed = 0.8f;
    //bool input_key_sensor = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.eulerAngles = new Vector3(45, 0, 0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //input_key_sensor = true;
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    posZ += 1.0f;
        //    input_key_sensor = false;
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    posZ -= 1.0f;
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    posX += 1.0f;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    posX -= 1.0f;
        //}
       
        posX = Input.GetAxisRaw("Horizontal");
        posZ = Input.GetAxisRaw("Vertical");
        
      

    }
    private void FixedUpdate()
    {
       
            //移動
            if (posX != 0 || posZ != 0)
        {
            rb.angularVelocity += new Vector3(posX * ball_speed, posY, posZ * ball_speed);
            transform.Rotate(posX * ball_speed, posY, posZ * ball_speed);
        }
        else
        {
            rb.angularVelocity *= 0.98f;
            if (posX < 0.98 || posZ < 0.98)
            {
                rb.angularVelocity *= 0.00f;
            }
        }
        

        if (Input.GetKey(KeyCode.Space))
        {

            // rb.angularVelocity = new Vector3(posX * 1000.0f, rb.angularVelocity.y, rb.angularVelocity.z);
            Debug.Log("スペースキー");

            rb.angularVelocity += new Vector3(posX + 2.0f, posY+10.0f, posZ + 2.0f);

        }
       
       

       

        

    

        //rb.angularVelocity = new Vector3(rb.angularVelocity.x, rb.angularVelocity.y, posZ * 3.0f);
    }
}
