using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class NewMonoBehaviourScript : MonoBehaviour
{
    
    Rigidbody rb;
    //入力
    float Move = 0.0f;
    float posY = 0.0f;
    float Rotation = 0.0f;
    //ボールの速度
    float ball_speed = 1.8f;
    float ball_Rotation_speed = 100.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ボールを回転させる
        //transform.eulerAngles = new Vector3(45, 0, 0);
        //Rigidbody取得
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //ボールを動かすキーの取得
        Move = Input.GetAxisRaw("Vertical");
        Rotation = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        Vector3 dir = transform.forward;
        //移動
        if (Move != 0 || Rotation != 0)
        {
            rb.angularVelocity +=
            new Vector3
            (Rotation * ball_speed,
            posY,
            Move * ball_speed);

            transform.Rotate(
                Rotation * ball_Rotation_speed,
                0,
                0
                );
        }
        //ボールの動きが0.98を下回ると停止
        else
        {
            rb.angularVelocity *= 0.98f;
            if (Move < 0.98 || Rotation < 0.98)
            {
                rb.angularVelocity *= 0.00f;
            }
        }

        //加速キーの取得と制御
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("スペースキー");

            rb.angularVelocity += new Vector3(Move + 2.0f, posY + 10.0f, Rotation + 2.0f);

        }
    }
}
