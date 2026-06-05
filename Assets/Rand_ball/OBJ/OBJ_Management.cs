using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


//オブジェクトのスコアを決める
public class OBJ_Management : MonoBehaviour
{

  


    public int Value = 0;
    public int HP = 0;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //名前を取得する
        //string gameObjectTagName = this.gameObject.tag;
        // Debug.Log(gameObjectTagName);
    }

    // Update is called once per frame
    void Update()
    { 
    
    
    }
    //オブジェクトに当たったとき
    public void TakeDamage(int Damage)
    {
        if(HP > 0)
        {
            //HPが0になるとスコアを得る
            HP -= Damage;
            Debug.Log("ダメージ数" + Damage);
            //プレイヤーをとばす
        }
        else if (HP <= 0)
        {
            HP = 0;
            
        }
    }

}
