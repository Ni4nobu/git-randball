using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


//オブジェクトのスコアを決める
//オブジェクトを破壊した時に出るバラバラにしたオブジェクトを管理する

public class OBJ_Management : MonoBehaviour
{
    //public GameObject SE;
    [SerializeField] private SE_Sound OBJ_SE_Sound;
    [SerializeField] private Transform brokenPrefab;

    private AudioSource audioSource = null;
    public AudioClip SE_Break;
    public AudioClip SE_Damage;

    public int Value = 0;
    public int HP = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }
    //オブジェクトに当たったとき
    public void TakeDamage(int Damage)
    {
        if(HP > 0)
        {
            PlaySE(SE_Damage);
            //HPが0になるとスコアを得る
            HP -= Damage;
            
            Debug.Log("ダメージ数" + Damage);
            //プレイヤーをとばす
        }
        else if (HP <= 0)
        {
            audioSource.Stop();
            //PlaySE(SE_Break);
            //AudioSource.PlayClipAtPoint(SE_Break, transform.position, 6f);
            HP = 0;
            if (SE_Break != null && OBJ_SE_Sound != null)
            {
                OBJ_SE_Sound.PlaySE(SE_Break);
                Debug.Log("SE");
            }
            Break();
        }
    }

    public void Break()
    {
        //if (Input.GetMouseButtonDown(0))
        {
            
            // Instantiate(SE, transform.position, transform.rotation); // 効果音Prefabを生成
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
    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("audiosource=null");
        }
    }
}


