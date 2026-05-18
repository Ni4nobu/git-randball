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
    float PosY = 0.0f;
    float Rotation = 0.0f;
    //ボールの速度
    float Ball_Speed = 1.8f;
    float Ball_Rotation_Speed = 100.0f;
    //加速速度
    float Ball_Accleration_Speed = 100.0f;
    float MaxSpeed = 25.0f;
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
        if (MaxSpeed> Move)
        {
            //移動
            if (Move != 0 || Rotation != 0)
            {
                rb.angularVelocity +=
                new Vector3
                (Rotation * Ball_Speed,
                PosY,
                Move * Ball_Speed);

                transform.Rotate(
                    Rotation * Ball_Rotation_Speed,
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
        }
        //加速キーの取得と制御
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("スペースキー");

            //rb.angularVelocity += new Vector3(0, 0, Move * Ball_Accleration_Speed);
            Move += Ball_Accleration_Speed;
        }
    }
}
