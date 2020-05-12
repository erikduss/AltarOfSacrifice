using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{

    public SpriteRenderer thisSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnMouseDown()
    {
        SceneManager.LoadScene("GameScene");
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
