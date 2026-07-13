using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Experimental.GraphView.GraphView;

public class OBJ_Move : MonoBehaviour
{
    GameObject player;
    //プレイヤーが後退できないようにする
    float Player_Move_Max = 0.0f;

    //public float distance = 3.0f;
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
            float x = player.transform.position.x ;
            float y = 30;
            float z = 10;


            Vector3 v3 = new Vector3(x, y, z);
            //プレイヤーが下がったときの位置より前の時このオブジェクトを動かす
            //プレイヤーが下がるとこのオブジェクトはその場に留まる
            if (player.transform.position.x < Player_Move_Max)
            {
                //プレイヤーの位置を保存
                Player_Move_Max = player.transform.position.x;
                transform.localPosition = v3;
            }
        }
    }

}
