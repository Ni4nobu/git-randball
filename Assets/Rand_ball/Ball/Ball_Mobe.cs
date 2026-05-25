using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;


//スコアの計算
//プレイヤーの操作
//オブジェクトの破壊

public class Ball_Mobe : MonoBehaviour
{
    public static Ball_Mobe instance;  // 唯一のインスタンス
    public int sentence;  // 取得する変数
    Rigidbody rb;
    //入力
    float Move = 0.0f;
    float PosY = 0.0f;
    float Rotation = 0.0f;
    //ボールの速度
    float Ball_Speed = 1.8f;
    //ボール回転スピード
    float Ball_Rotation_Speed = 100.0f;
    //加速速度
    float Ball_Accleration_Speed = 100.0f;
    //制限速度
    float MaxSpeed = 25.0f;
    //スコア
    public  int score = 0;

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
        if(Input.GetKey(KeyCode.Return))
        {
            //メニュー画面
#if UNITY_EDITOR
            // Unityエディターでの動作
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // 実際のゲーム終了処理
        Application.Quit();
#endif
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            //ゲーム終了
#if UNITY_EDITOR
            // Unityエディターでの動作
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // 実際のゲーム終了処理
        Application.Quit();
#endif
        }
    }
    private void FixedUpdate()
    {
       
        Vector3 dir = transform.forward;
        if (MaxSpeed> Move)
        {
            //移動
            if (Move != 0 || Rotation != 0)
            {
                //ワールドの軸を元に移動　（オブジェクトの軸は使うと難しい）
                rb.angularVelocity +=
                new Vector3
                (Rotation * Ball_Speed,
                PosY,
                Move * Ball_Speed);

                //ボールの回転
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

            rb.angularVelocity += new Vector3(0, 0, (Move) * Ball_Accleration_Speed);
            //Move += Ball_Accleration_Speed;
        }
    }
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

            Debug.Log("Score");
        }
    }
    void Awake()
    {
        // インスタンスがまだ作られていなければ自分を代入
        if (instance == null)
        {
            instance = this;
        }
    }

}
