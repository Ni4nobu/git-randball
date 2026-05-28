using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

//プレイヤーの操作
//オブジェクトの破壊
//スコアの計算

public class Ball_Mobe : MonoBehaviour
{
    public static Ball_Mobe instance;  // 唯一のインスタンス
    public int sentence;  // 取得する変数
    Rigidbody rb;
    //入力
    float Move = 0.0f;
    float PosY = -3.0f;
    float Rotation = 0.0f;
    //ボールの速度
    float CurrentSpeed = 0.0f;              //ボールの速度をコントロール
    float Ball_Speed = 1.8f;                //通常の速度
    float Ball_Accleration_Speed = 13.0f;    //加速時の速度
    //ボール回転スピード
    float Ball_Rotation_Speed = 100.0f;
    //スペースキーの入力
    bool SpeedUp = false;

    //スタミナ
   // float Max_Stamina = 100.0f;//最大スタミナ
  //  float Stamina_Consumption = 1.0f;//スタミナ消費

    //制限速度
    float Max_Speed = 250.0f;
    //スコア
    public  int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        transform.eulerAngles = new Vector3(0, 0, 0); //ボールを回転させる

        rb = GetComponent<Rigidbody>();  //Rigidbody取得
    }

    // Update is called once per frame
    void Update()
    {

        //ボールを動かすキーの取得
        Move = Input.GetAxisRaw("Vertical");
        Rotation = Input.GetAxisRaw("Horizontal");

        // ダッシュキーの検知
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //押した
            SpeedUp = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //離した
            SpeedUp = false;
        }
       
        //ゲーム終了
        if (Input.GetKey(KeyCode.Escape))
        {
            
        #if UNITY_EDITOR
            // Unityエディターでの動作
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        // 実際のゲーム終了処理
        Application.Quit();
        #endif
        }
    }
    //プレイヤーの移動
    private void FixedUpdate()
    {
       
        Vector3 dir = transform.forward ;
        Vector3 Move_Dir = transform.forward * Move * CurrentSpeed;
        //Vector3 force = new Vector3(30.0f, 0.0f, 0.0f);
        //rb.AddForce(force); // 力を加える

        if (Max_Speed > Move)
        {
            //移動
            if (Move != 0 || Rotation != 0)
            {
                //ワールドの軸を元に移動　（オブジェクトの軸は使うと難しい）

                rb.angularVelocity +=
                new Vector3
                (Rotation * CurrentSpeed,
                PosY,
                Move * CurrentSpeed);

                rb.linearVelocity =
                new Vector3
                (-Move * CurrentSpeed,
                PosY,
                Rotation * CurrentSpeed);

                //ボールの回転
                transform.Rotate(
                    Rotation * Ball_Rotation_Speed * Time.fixedDeltaTime,
                    0,
                    0
                    );
            }
            //ボールの動きが0.98を下回ると停止
            else
            {
                rb.angularVelocity *= 0.98f;
                if (Move < 0.098f || Rotation < 0.098f)
                {
                    //rb.angularVelocity *= 0.00f;
                    //rb.linearVelocity *= 0.00f;
                }
            }
        }
        //ダッシュ
        if (SpeedUp == true)
        {
            //速度を足す

            //Debug.Log("スペースキー");
            Debug.Log("ボールの速度" + CurrentSpeed);
            CurrentSpeed = Ball_Speed  * Ball_Accleration_Speed;
            Debug.Log("ボールの速度" + CurrentSpeed);
        }
        //通常
        else if (SpeedUp == false)
        {
            //速度を戻す
            CurrentSpeed = Ball_Speed;
            //Debug.Log("ボールの速度"+CurrentSpeed);
        }
    }

    //スコアの計算
    void OnTriggerEnter(Collider other)
    {
       
        //if (collision.gameObject.CompareTag("Player"))
        //スコア
        if (other.gameObject.CompareTag("Score"))
        {  
            OBJ_Management Obj_Score = other.gameObject.GetComponent<OBJ_Management>();
            //スコアを得る
            score = Obj_Score.Value;
            sentence += score;

            //オブジェクトを削除
            Destroy(other.gameObject);

            Debug.Log("Score"+ score);
        }
    }
    //インスタンス
    void Awake()
    {
        // インスタンスがまだ作られていなければ自分を代入
        if (instance == null)
        {
            instance = this;
        }
    }

}
