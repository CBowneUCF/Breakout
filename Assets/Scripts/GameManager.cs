using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-50)] // Run before everything else.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Config

    public int startingLives = 5;
    public TextMeshProUGUI scoreText;
    public Paddle paddle;
    public Ball ball;
    public GameObject[] livesImage;
    public GameObject gameOver;
    public GameObject youWin;
    public Brick[] bricks { get; private set; }

    //Data
    public static int lives; //Static (global) values so it can be accessed from anywhere without getting the GameManager.
    public static int score;
    public static int bricksLeft; //Counter for bricks in scene. Ticked up on brick Awake and down on Brick Death. Much more efficient than counting objects.




    private void Awake()
    {
        instance = this;
        lives = startingLives;
        bricksLeft = 0;
    }

    public void BrickHit(bool brickDestroyed)
    {
        score += 10;
        scoreText.SetText("Score: " + score);
        if (brickDestroyed) bricksLeft--;
        //Don't need separate function call.
        if (bricksLeft == 0)
        {
            youWin.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void BallDeath()
    {
        if (lives <= 0)
        {
            //Don't need separate Function call.
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            //Tell Ball and Paddle to reset position themselves as they have direct access to data and components.
            //Fun fact: Hold control and click on a field or Function to jump to it's definition.
            ball.ResetPosition();
            paddle.ResetPosition();
            lives--;
            livesImage[lives].SetActive(false);
        }
    }

    //Wholely unnecessary thanks to BricksLeft Counter.
    //public bool Clear()
    //{
    //    for (int i = 0; i < this.bricks.Length; i++)
    //    {
    //        if (this.bricks[i].gameObject.activeInHierarchy)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    public void Restart() => SceneManager.LoadScene("SampleScene");

}
