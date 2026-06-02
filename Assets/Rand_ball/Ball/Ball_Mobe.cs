using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;
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
    float Ball_Speed = 4.8f;                //通常の速度
    float Ball_Accleration_Speed = 10.5f;   //加速時の速度
    //ボール回転スピード
    float AA_Current_Rotation_Speed = 0.0f;//ボールの回転速度コントロール
    float Ball_Rotation_Speed = 100.0f;
    float AA_Ball_Rotation_Accleration_Speed = 200.0f;//加速時
    //スペースキーの入力
    bool SpeedUp = false;

    //スタミナ
    float Max_Stamina = 100.0f;//最大スタミナ
    float Stamina_Consumption = 10.0f;//スタミナ消費
    float Stamina_Recovery = 2.0f;//スタミナ回復
    float Stamina = 0.0f;//スタミナ

    //制限速度
    float Max_Speed = 250.0f;
    //スコア
    public  int score = 0;

  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Max_Stamina = 100.0f;//最大スタミナ
        Stamina = Max_Stamina;

        CurrentSpeed = 0.0f;
        AA_Current_Rotation_Speed = 0.0f;//ボールの回転速度コントロール

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
                0.0f,
                Move * CurrentSpeed);

                rb.linearVelocity =
                new Vector3
                (-Move * CurrentSpeed,
                PosY,
                Rotation * CurrentSpeed);

                //ボールの回転
                transform.Rotate(
                    Rotation * AA_Current_Rotation_Speed * Time.fixedDeltaTime,
                    0,
                    0
                    );
            }
            //ボールの動きが0.98を下回ると停止
            else
            {
                //linearVelocity
                Vector3 L_Vector = rb.linearVelocity;
                //減速
                Vector3 A_Vector = rb.angularVelocity;
                //rb.angularVelocity *= 0.98f;

                A_Vector.x *= 0.98f;
                A_Vector.y *= 0.98f;

                L_Vector.x *= 0.98f;
                L_Vector.z *= 0.98f;

                //if (L_Vector.x > 0.1f && L_Vector.x > -0.1f
                //   || L_Vector.z > 0.1f && L_Vector.z > -0.1f)
                    if (Move < 0.98f || Rotation < 0.98f)
                {
                    //rb.angularVelocity *= 0.00f;
                    L_Vector.x *= 0.00f;
                    L_Vector.z *= 0.00f;

                    A_Vector.x *= 0.00f;
                    A_Vector.y *= 0.00f;
                }
            }
        }
        //ダッシュ
        if (SpeedUp == true && Stamina>0.0f)
        {
            //速度を足す

            //Debug.Log("スペースキー");
            // Debug.Log("ボールの速度" + CurrentSpeed);
            AA_Current_Rotation_Speed = Ball_Rotation_Speed; //ボール回転
             CurrentSpeed = Ball_Accleration_Speed; //ボール移動

            Stamina -= Stamina_Consumption * Time.fixedDeltaTime;//スタミナを減らす
            Debug.Log("スタミナ:" + Stamina);
            //70を下回ってもスペースキーを離さないと加速できるのを防ぐ
            if(Stamina <= 0.0f)
            {
                Stamina = 0.0f;
                Debug.Log("スタミナ:" + Stamina);
                SpeedUp = false;    
            }
        }
        //通常
        else if (SpeedUp == false)
        {
           // Debug.Log("通常");
            //速度を戻す
            CurrentSpeed = Ball_Speed;//ボール移動
            AA_Current_Rotation_Speed = AA_Ball_Rotation_Accleration_Speed;//ボール回転
            //スタミナ回復
            if (Stamina <= Max_Stamina)
            {
                Stamina += Stamina_Recovery * Time.fixedDeltaTime;
            }
           

            //ボールの速度を戻していく
            if (CurrentSpeed > Ball_Speed)
            {
               
                CurrentSpeed -= 0.5f;
                if (CurrentSpeed < Ball_Speed)
                {
                    CurrentSpeed = Ball_Speed;
                }
                    Debug.Log("減速" + CurrentSpeed);
            }
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
            //コンポーネントを得る
            OBJ_Management OBJ = other.gameObject.GetComponent<OBJ_Management>();
            if (OBJ == null)
            {
                return;
            }

            if (OBJ.HP <= 0)
            {
                
                //スコアを得る
                score = OBJ.Value; //Debug.Log("オブジェクト名" + other.name);
                sentence += score;

                //オブジェクトを削除
                Destroy(other.gameObject);

                Debug.Log("Score" + score);
            }
            else
            {
              
                OBJ.TakeDamage(1);
            }
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
