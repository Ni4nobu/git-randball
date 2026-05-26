using UnityEngine;


//オブジェクトのスコアを決める
public class OBJ_Management : MonoBehaviour
{
    public int Value = 0;
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
    private void OnCollisionEnter(Collision collision)
    {
        //当たったオブジェクトがPlayer
        //if (collision.gameObject.CompareTag("Player"))
        //{  //オブジェクトを削除
        //    Destroy(gameObject);
        //    Debug.Log("Player衝突");

        //}
    }

}
