using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : Collectable
{
    public Sprite emptyChest;
    public int pesosAmout = 10;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GameManager.instance.cobble += pesosAmout;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + pesosAmout + " cobble !", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
        
}
