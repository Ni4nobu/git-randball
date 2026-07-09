using UnityEngine;
using UnityEngine.UI;

public class Dash_Bar : MonoBehaviour
{
    [SerializeField] private Slider Stumina_Slider;
   // [SerializeField] private int max_Stumina = 100;
    private int Current_Stumina;
    public Image fillImage;
   // Color baseColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 初期設定
        //Current_Stumina = max_Stumina;
        //Stumina_Slider.maxValue = max_Stumina;
        //Stumina_Slider.value = Current_Stumina;

    }

    public void TakeDash(float Dash)
    {
        // スライダーに現在反映
        // Current_Stumina -= Dash;    
        //Current_Stumina  = Mathf.Max(0, Current_Stumina);
        //  Stumina_Slider.value = Current_Stumina;
        Stumina_Slider.value = Dash;
        float a = Dash / 300f; // 0から1に変換
        //float a = Dash / 100f; // 0から1に変換

    }
}
