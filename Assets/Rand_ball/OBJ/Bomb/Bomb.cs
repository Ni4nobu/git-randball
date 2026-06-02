using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bomb : MonoBehaviour
{
    float Bonb_Renge;
    public static Bomb instance;  // 唯一のインスタンス
    //スコア
    public int score = 0;
    public int sentence;  // 取得する変数
    //public int Value = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //名前を取得する
        string gameObjectTagName = this.gameObject.tag;
        Bonb_Renge = 5.0f;
        //Debug.Log(gameObjectTagName);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
   
    void OnTriggerEnter(Collider other)
    {
        //当たったオブジェクトがPlayer
        if (other.gameObject.CompareTag("Player"))
        {  //オブジェクトを削除


            //Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Explode();
            Destroy(gameObject);
            Debug.Log("Player衝突");
        }
    }
    void Explode()
    {
        // 爆弾の中心から半径5の範囲にあるコライダーを取得
        Collider[] hits = Physics.OverlapSphere(transform.position, Bonb_Renge);

        foreach (Collider hit in hits)
        {
            // Scoreタグだけ削除
            if (hit.CompareTag("Score"))
            {
                //コンポーネントを得る
                OBJ_Management Obj_Score = hit.gameObject.GetComponent<OBJ_Management>();
                //スコアを得る
                score = Obj_Score.Value; //Debug.Log("オブジェクト名" + other.name);
                sentence += score;

                //オブジェクトを削除
                Destroy(hit.gameObject);
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
