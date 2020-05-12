using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject attackStyles;
    public GameManager gameController;
    public int health = 100;

    public List<Sprite> playerImages = new List<Sprite>();
    public int currentImage = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.playerTurn == 1)
        {
            if(health > 0)
            {
                attackStyles.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("EndScene");
            }
        }
        else
        {
            attackStyles.SetActive(false);
        }
    }

    public void attackEnemy(string attackStyle)
    {
        if(attackStyle == "Attack_1")
        {
            int damageDone = Random.Range(0, 100);
            gameController.dealDamage(2, damageDone);
        }
        else if (attackStyle == "Attack_2")
        {
            int damageDone = Random.Range(0, 100);
            gameController.dealDamage(2, damageDone);
        }
        else if (attackStyle == "Attack_3")
        {
            int damageDone = Random.Range(0, 100);
            gameController.dealDamage(2, damageDone);
        }
    }
}
