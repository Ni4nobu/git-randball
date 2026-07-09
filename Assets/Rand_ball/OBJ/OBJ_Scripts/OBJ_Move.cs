using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class OBJ_Move : MonoBehaviour
{
    GameObject player;
    //プレイヤーが後退できないようにする
    float Player_Move_Max = 0.0f;

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
            float x = player.transform.position.x + 4;
            float y = -2;
            float z = 0;


            Vector3 v3 = new Vector3(x, y, z);
            transform.localPosition = v3;

            //プレイヤーが戻っていい距離を保存
            x = Player_Move_Max;
        }
        if(player.transform.position.x > Player_Move_Max)
        {
            Player_Move_Max = player.transform.position.x;
        }
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * 5 * Time.deltaTime;
        }
    }

}
