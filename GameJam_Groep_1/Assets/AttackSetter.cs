using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSetter : MonoBehaviour
{
    private PlayerController player;
    private SpriteRenderer thisImage;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        thisImage = this.GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        player.attackEnemy(this.gameObject.name);
        thisImage.color = Color.white;
    }

    void OnMouseEnter()
    {
        thisImage.color = Color.grey;
    }
    void OnMouseExit()
    {
        thisImage.color = Color.white;
    }
}
