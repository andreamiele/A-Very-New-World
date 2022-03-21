using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActiver : MonoBehaviour
{
    public void Test()
    {
        Player player = GameManager.instance.justClickedPlayer;


        if (player.active)
        {

            player.active = false;
            GameManager.instance.mobilisedSettlers.Remove(player);
        }
        else
        {

            player.active = true;
            GameManager.instance.mobilisedSettlers.Add(player);
        }
        
    }
}
