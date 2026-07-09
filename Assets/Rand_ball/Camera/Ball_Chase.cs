using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


//カメラの制御

//前に移動するとカメラが前を向く　後ろを向くと後ろを向く　移動しないと前を向く
//左右は移動するときにカメラも前を移しながら左右移動する
//プレイヤーの左右の移動を方向転換にする

public class Ball_Chase : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.fullScreen = false;
        Screen.SetResolution(1280, 720, false);
        //カーソルキーを消す
        Cursor.lockState = CursorLockMode.Locked;//カーソルを動かしても画面から出ない
        Cursor.visible = false;//カーソルを非表示
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //プレイヤーの位置取得
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");
        if (player != null )
        {
            //カメラの位置
            float x = player.transform.position.x + 4;
            float y = player.transform.position.y + 2;
            float z = player.transform.position.z;

            Vector3 v3 = new Vector3(x, y, z);
            transform.localPosition = v3;

            //マウスカーソルで左右視点移動
            float mx = Input.GetAxis("Mouse X");//カーソルの横の移動量を取得
            float my = Input.GetAxis("Mouse Y");//カーソルの縦の移動量を取得

            //マウスの左クリックを押している間視点をマウスで動かせる
            if (Input.GetMouseButton(0))
            {
                //Debug.Log("左クリックされた");
                if (Mathf.Abs(mx) > 0.001f) // X方向に一定量移動していれば横回転
                {
                    transform.RotateAround(player.transform.position, Vector3.up, mx); // 回転軸はplayerオブジェクトのワールド座標Y軸

                }
            }
            //マウスで動かした視点をマウスホイールでリセット
            if (Input.GetMouseButtonUp(2))
            {
                transform.eulerAngles = new Vector3(165, 90, 180);
            }


        }
    }
}
