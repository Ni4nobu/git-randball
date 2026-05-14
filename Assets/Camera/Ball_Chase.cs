using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball_Chase : MonoBehaviour
{
    float posX = 0.0f;
    float posY = 0.0f;
    float posZ = 0.0f;
    float Chase_speed = 0.8f;
    //public float topLimit = 0.0f;
    //public float bottomLimit = 0.0f;
    //public float leftLimit = 0.0f;
    //public float rightLimit = 0.0f;
    //public float frontLimit = 0.0f;
    //public float backLimit = 0.0f;
    //public Vector3 offset = new Vector3(3, 2, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // transform.eulerAngles = new Vector3(165, 90, 180);
        Screen.fullScreen = false;
        Screen.SetResolution(1280, 720, false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    
    void Update()
    {
        //posX = Input.GetAxisRaw("Horizontal");
        //posZ = Input.GetAxisRaw("Vertical");
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");
        if (player != null )
        {
            float x = player.transform.position.x + 3;
            float y = player.transform.position.y + 2;
            float z = player.transform.position.z;

            Vector3 v3 = new Vector3(x, y, z);
            transform.localPosition = v3;

            //transform.position = player.transform.position + offset;
            //transform.LookAt(player.transform);
            //マウスカーソルで左右視点移動
            float mx = Input.GetAxis("Mouse X");//カーソルの横の移動量を取得
            float my = Input.GetAxis("Mouse Y");//カーソルの縦の移動量を取得
            //new Vector3(posX * 1.0f, posY, posZ * 1.0f);
            //float my = Input.GetAxis("Mouse Y");//マウスの横方向の移動量を取得
            if (Input.GetMouseButton(0))
            {
                Debug.Log("左クリックされた");
                if (Mathf.Abs(mx) > 0.001f) // X方向に一定量移動していれば横回転
                {
                    transform.RotateAround(transform.position, Vector3.up, mx); // 回転軸はplayerオブジェクトのワールド座標Y軸

                }
                if (Mathf.Abs(my) > 0.001f)// Y方向に一定量移動していれば縦回転
                {
                    //transform.RotateAround(player.transform.position, Vector3.right, -my);
                }
               // transform.RotateAround(player.transform.position, Vector3.up, mx);
               // transform.RotateAround(player.transform.position, transform.right, my);

               // player.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);   // プレイヤーの向きを変更させる処理

            }
            if (Input.GetMouseButtonUp(2))
            {
                transform.eulerAngles = new Vector3(165, 90, 180);
            }
            //前に移動するとカメラが前を向く　後ろを向くと後ろを向く　移動しないと前を向く
            //左右は移動するときにカメラも前を移しながら左右移動する
            //プレイヤーの左右の移動を方向転換にする
            posX = Input.GetAxisRaw("Horizontal");
          　posZ = Input.GetAxisRaw("Vertical");
            //移動
            if (posX != 0 || posZ != 0)
            {
                //Component camera1 = camera;
                //Vector3 pos = player.transform.position + camera1.transform.forward * Chase_speed;

            }

        }
        
    }
}
