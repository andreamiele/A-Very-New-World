using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject toEnable;
    private bool activated = false;


    public void OnMouseDown()
    {
        activate();
    }
    public void activate()
    {
        if (activated == true) { activated= false; toEnable.SetActive(false); }
        else { activated = true; toEnable.SetActive(true); }
    }
}
