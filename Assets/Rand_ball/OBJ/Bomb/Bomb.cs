using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bomb : MonoBehaviour
{
    
    //public int Value = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //名前を取得する
        string gameObjectTagName = this.gameObject.tag;
        //Debug.Log(gameObjectTagName);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public List<GameObject> Scores = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        //当たったオブジェクトがPlayer
        if (other.gameObject.CompareTag("Player"))
        {  //オブジェクトを削除

           Destroy(gameObject);
            Debug.Log("Player衝突");
            //Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Scores.Add(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("Score"))
        {

            //コンポーネントを得る
            OBJ_Management Obj_Score = other.gameObject.GetComponent<OBJ_Management>();
            //スコアを得る
            //score = Obj_Score.Value; 
            //sentence += score;

            //オブジェクトを削除
            Destroy(other.gameObject);
            Debug.Log("オブジェクト削除");
            //Debug.Log("Score" + score);
            Scores.Remove(other.gameObject);
        }
    }
    


}
