using UnityEngine;

//オブジェクトを破壊した時に出るバラバラにしたオブジェクトを管理する

public class OBJ_Breakable : MonoBehaviour
{
    [SerializeField] private Transform brokenPrefab;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Transform brokenTransform = Instantiate(brokenPrefab,transform.position,transform.rotation);
            brokenTransform.localScale = transform.localScale;

            Destroy(gameObject);
        }

    }
}
