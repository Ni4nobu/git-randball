using UnityEngine;

public class Operation : MonoBehaviour
{
    private AudioSource audioSource = null;//‰¹

    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject Controll_Canvas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();//‰¹
    }

    // Update is called once per frame
    void Update()
    {

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
