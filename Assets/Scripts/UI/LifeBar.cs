using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image[] barLigths;
    public Color leftColor;
    public Color rightColor;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < barLigths.Length;i++) {
            barLigths[i].color = Color.Lerp(leftColor, rightColor, i/(float)(barLigths.Length-1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
