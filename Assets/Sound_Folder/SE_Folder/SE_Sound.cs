using UnityEngine;
using UnityEngine.Audio;

public class SE_Sound : MonoBehaviour
{
    //public AudioClip Tree_SE;
    //public AudioClip Rock_SE;
    //public AudioClip Trash_SE;

    private AudioSource audioSource = null;

    //[SerializeField] private OBJ_Management OBJ_SE_Sound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //if (OBJ_SE_Sound.SE_Break != null && OBJ_SE_Sound.SE_Break.name == "PrivaDeck_volume_300pct_ñŒÇ›ÉKÉTÉKÉT")
        //{
        //    PlaySE(Tree_SE);
        //    Debug.Log("PrivaDeck_volume_300pct_ñŒÇ›ÉKÉTÉKÉT");
        //}
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
