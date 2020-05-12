using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{
    public SpriteRenderer thisSprite;
    // Start is called before the first frame update


    void OnMouseDown()
    {
        Application.Quit();
    }

    void OnMouseEnter()
    {
        thisSprite.color = Color.grey;
    }
    void OnMouseExit()
    {
        thisSprite.color = Color.white;
    }
}
