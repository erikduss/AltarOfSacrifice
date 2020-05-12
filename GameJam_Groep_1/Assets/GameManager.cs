using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerTurn = 1;
    public PlayerController Player;
    public EnemyController Enemy;

    public Text enemyHealh_Text;
    public Text playerHealh_Text;

    public GameObject playerBarFill;
    public GameObject enemyBarFill;

    public int enemiesKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "EndScene")
        {
            Text endtext = GameObject.FindGameObjectWithTag("endText").GetComponent<Text>();
            endtext.text = "You made " + enemiesKilled + " sacrifices this time";

            if (Input.anyKey)
            {
                SceneManager.LoadScene("StartScene");
            }
        }
        if(SceneManager.GetActiveScene().name == "StartScene")
        {
            Destroy(this.gameObject);
        }
    }

    public void EndTurn()
    {
        if(playerTurn == 1)
        {
            Enemy.attacking = false;
            playerTurn = 2;
        }
        else
        {
            playerTurn = 1;
        }
    }

    public void dealDamage(int player, int damage)
    {
        if(player == 1)
        {
            Player.health -= damage;
            playerHealh_Text.text = "HP: " + Player.health;
            playerBarFill.transform.localScale = new Vector3((float)Player.health / 100, 1, 1);
        }
        else
        {
            Enemy.health -= damage;
            enemyHealh_Text.text = "HP: " + Enemy.health;
            enemyBarFill.transform.localScale = new Vector3((float)Enemy.health / 100, 1, 1);
        }

        EndTurn();
    }

    public void enemyDied()
    {
        enemiesKilled++;
        Enemy.health = 0;
        enemyHealh_Text.text = "HP: " + Enemy.health;
        enemyBarFill.transform.localScale = new Vector3((float)Enemy.health / 100, 1, 1);
        Enemy.currentSprite++;
        Enemy.GetComponent<SpriteRenderer>().sprite = Enemy.enemyImages[Enemy.currentSprite];
        Player.health += (Random.Range(25, 50));
        if (Player.health > 100) Player.health = 100;
        playerHealh_Text.text = "HP: " + Player.health;
        playerBarFill.transform.localScale = new Vector3((float)Player.health / 100, 1, 1);
        if(Player.currentImage < 3) Player.currentImage++;
        Player.GetComponent<SpriteRenderer>().sprite = Player.playerImages[Player.currentImage];

        StartCoroutine(diedAnimation());
    }

    IEnumerator diedAnimation()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        Enemy.health = 100;
        enemyHealh_Text.text = "HP: " + Enemy.health;
        enemyBarFill.transform.localScale = new Vector3((float)Enemy.health / 100, 1, 1);
        int currentEnemySprite = (Random.Range(0, 6)) * 2;
        Enemy.currentSprite = currentEnemySprite;
        Enemy.GetComponent<SpriteRenderer>().sprite = Enemy.enemyImages[Enemy.currentSprite];
        EndTurn();
        Enemy.died = false; 
    }
}
