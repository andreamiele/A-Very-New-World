using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active); // Find one that is not active in floatingTexts

        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }
        return txt;

    }

    private void Update()
    {
        foreach (FloatingText txt in floatingTexts)
            txt.UpdateFloatingText();
    } // Update every floating text in the array every second 

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText txt = GetFloatingText();

        txt.txt.text = msg;
        txt.txt.fontSize = fontSize;
        txt.txt.color = color;

        txt.go.transform.position = Camera.main.WorldToScreenPoint( position); // Transfer world space to screen space so we can use it in the UI.
        txt.motion = motion;
        txt.duration = duration;

        txt.Show();
    }
}
