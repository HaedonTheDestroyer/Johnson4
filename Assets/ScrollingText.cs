using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*public class ScrollingText : MonoBehaviour
{
    [TextArea][SerializeField] private string[] iteminfo;
    [SerializeField] private Color[] colors;
    [SerializeField] private float textSpeed = 0.01f;
    public bool leo = false;

    [SerializeField] private TextMeshProUGUI itemInfoText;
    private int currentDisplayingText = 0;    // Start is called before the first frame update
    
    public void ActivateText()
    {
        //StartCoroutine(AnimateText());
        
    }
    IEnumerator AnimateText()
    {
        for (int i = 0; i < iteminfo[currentDisplayingText].Length + 1; i++)
        {
            itemInfoText.color= colors[currentDisplayingText];
            itemInfoText.text = iteminfo[currentDisplayingText].Substring(0, i);
            
            yield return new WaitForSeconds(textSpeed);
        }
        currentDisplayingText++;
    }
    
}*/
