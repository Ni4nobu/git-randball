using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
    //スペースキーの入力 加速
    bool SpeedUp = false;

    //スタミナ
    float Max_Stamina = 100.0f;//最大スタミナ
    float Stamina_Consumption = 10.0f;//スタミナ消費
    float Stamina_Recovery = 2.0f;//スタミナ回復
    float Stamina = 0.0f;//スタミナ
    bool Stamina_Status = false;//加速しているかどうか
    [SerializeField] Dash_Bar DB;//メンバ変数に保存

    //制限速度
    float Max_Speed = 250.0f;
    //スコア
    public  int score = 0;

    //ノックバック
    float Power = 1700.0f;
    
    //public Transform attacker;
    bool  KnockBack_Status = false;
    float KnockBack_Time = 0.8f;
    float KnockBack_Timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Max_Stamina = 100.0f;//最大スタミナ
        Stamina = Max_Stamina;

        CurrentSpeed = 0.0f;
        AA_Current_Rotation_Speed = 0.0f;//ボールの回転速度コントロール

        transform.eulerAngles = new Vector3(0, 0, 0); //ボールを回転させる

        rb = GetComponent<Rigidbody>();  //Rigidbody取得
        //DB = GetComponent<Dash_Bar>();
        DB.TakeDash(Stamina);//スタミナ反映用

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
        //ノックバック時間
       if(KnockBack_Status == true )
        {
            KnockBack_Timer -= Time.fixedDeltaTime;

            if (KnockBack_Timer<=0)
            {
                KnockBack_Status = false;
            }
            return;
        }
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
        if (KnockBack_Status == false)
        {
            if (SpeedUp == true && Stamina > 0.0f)
            {
                Stamina_Status = true;
                //速度を足す

                //Debug.Log("スペースキー");
                // Debug.Log("ボールの速度" + CurrentSpeed);
                AA_Current_Rotation_Speed = Ball_Rotation_Speed; //ボール回転
                CurrentSpeed = Ball_Accleration_Speed; //ボール移動

                Stamina -= Stamina_Consumption * Time.fixedDeltaTime;//スタミナを減らす

                DB.TakeDash(Stamina);//スタミナ反映用
                Debug.Log("スタミナ:" + Stamina);
                //70を下回ってもスペースキーを離さないと加速できるのを防ぐ
                if (Stamina <= 0.0f)
                {
                    Stamina = 0.0f;

                    DB.TakeDash(Stamina);//スタミナ反映用
                    Debug.Log("スタミナ:" + Stamina);
                    SpeedUp = false;
                }
            }
            //通常
            else if (SpeedUp == false)
            {
                Stamina_Status = false;
                // Debug.Log("通常");
                //速度を戻す
                CurrentSpeed = Ball_Speed;//ボール移動
                AA_Current_Rotation_Speed = AA_Ball_Rotation_Accleration_Speed;//ボール回転
                                                                               //スタミナ回復
                if (Stamina <= Max_Stamina)
                {

                    Stamina += Stamina_Recovery * Time.fixedDeltaTime;
                    DB.TakeDash(Stamina);//スタミナ反映用
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
        if (KnockBack_Status == true && SpeedUp == true)
        {

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
            if (Stamina_Status == true)
            {
               
                OBJ.TakeDamage(20);
            }
            else if (Stamina_Status == false)
            {
              
                OBJ.TakeDamage(1);
            }
            if (OBJ.HP <= 0)
            {
                //KnockBackCustom(other.transform, Power);
                //スコアを得る
                score = OBJ.Value; //Debug.Log("オブジェクト名" + other.name);
                sentence += score;

                //オブジェクトを削除
                //Destroy(other.gameObject);
                OBJ.TakeDamage(1);
                if (Stamina < Max_Stamina)
                {
                    Stamina += 3.0f;
                    DB.TakeDash(Stamina);//スタミナ反映用
                    Debug.Log("Score" + score);
                    if (Stamina > Max_Stamina)
                    {
                        Stamina = Max_Stamina;
                        DB.TakeDash(Stamina);//スタミナ反映用
                        Debug.Log("Score" + score);
                    }
                        
                }
               
                
            }
            else
            {
                KnockBackCustom(other.transform, Power);
                //KnockBackCustom(other.transform, Power);
                //if (Stamina_Status == true)
                //{
                //    OBJ.TakeDamage(5);
                //}
                //else if (Stamina_Status == false)
                //{
                //    OBJ.TakeDamage(1);
                //}

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
    // 方向と強さを計算してノックバックを与えるメソッド
    public void KnockBackCustom(Transform attacker, float power)
    {
        if (attacker == null)
        {
            Debug.Log("attackerがnull");
            return;
        }

        // 攻撃を受けた位置と攻撃者の位置から方向を計算
        Vector3 direction = (transform.position - attacker.position).normalized;

        direction.y = 0.0f;
        //ノックバック状態ON
        KnockBack_Status = true;
        KnockBack_Timer = KnockBack_Time;
        // 計算した方向と強さを使って吹き飛ばす
        rb.AddForce(direction * power, ForceMode.Impulse);
    }

}
