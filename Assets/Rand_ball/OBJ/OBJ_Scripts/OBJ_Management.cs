using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


//オブジェクトのスコアを決める
//オブジェクトを破壊した時に出るバラバラにしたオブジェクトを管理する

public class OBJ_Management : MonoBehaviour
{

    [SerializeField] private Transform brokenPrefab;


    public int Value = 0;
    public int HP = 0;
   
   
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
            Break();
        }
    }

    public void Break()
    {
        //if (Input.GetMouseButtonDown(0))
        {
            // 破片オブジェクトを生成
            Transform brokenTransform = Instantiate(brokenPrefab, transform.position, transform.rotation);
            brokenTransform.localScale = transform.localScale;

            foreach (Rigidbody rigidbody in brokenTransform.GetComponentsInChildren<Rigidbody>())
            {
                //吹き飛ばす力、
                rigidbody.AddExplosionForce(200.0f, transform.position + Vector3.up * 0.5f, 0.5f);
            }
            //コライダー消す
            GetComponent<Collider>().enabled = false;
            //おおもとのオブジェクトの削除
            Destroy(gameObject);
            // Destroy(brokenPrefab);
            //破片を破壊 + 何秒後か
            Destroy(brokenTransform.gameObject, 4.0f);
        }
    }
}


