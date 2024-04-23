using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    [TextArea][SerializeField] private string[] iteminfo;
    [SerializeField] private Color[] colors;
    [SerializeField] private float textSpeed = .1f;
    public bool leo = false;

    [SerializeField] private TextMeshProUGUI itemInfoText;
    public TMP_Text tm;
    private int currentDisplayingText = 0;    // Start is called before the first frame update
    public void Start()
    {
        //tm=GetComponent<TMP_Text>();
    }
    public void Update()
    {
        itemInfoText.ForceMeshUpdate();
        //tm.ForceMeshUpdate(true);
    }
    public void ActivateText()
    {
        Debug.Log("go");
        
        StartCoroutine(AnimateText());
        Debug.Log("go2");

    }
    IEnumerator AnimateText()
    {
        itemInfoText.color = colors[currentDisplayingText];
        // itemInfoText.ForceMeshUpdate(true,true);
        for (int i = 0; i < iteminfo[currentDisplayingText].Length + 1; i++)
        {
            //itemInfoText.color= colors[currentDisplayingText];
            itemInfoText.text = iteminfo[currentDisplayingText].Substring(0, i);
           // itemInfoText.ForceMeshUpdate(true, true);
            yield return new WaitForSeconds(textSpeed);
        }
        
        currentDisplayingText++;
    }
    
}
