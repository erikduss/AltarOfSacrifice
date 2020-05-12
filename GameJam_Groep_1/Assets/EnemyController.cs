using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameController;
    public int health = 100;
    public bool attacking = false;

    public List<Sprite> enemyImages = new List<Sprite>();

    public int currentSprite = 0;

    public bool died = false;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.playerTurn == 2 && !attacking && health > 0)
        {
            StartCoroutine(attackPlayer());
        }
        else if(health <= 0 && gameController.playerTurn == 2 && !died)
        {
            died = true;
            gameController.enemyDied();
        }
    }

    IEnumerator attackPlayer()
    {
        attacking = true;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        int damageDone = Random.Range(0, 60);
        gameController.dealDamage(1, damageDone);
    }
}
