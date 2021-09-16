using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public GameObject hudPanel;
    public GameObject resultPanel;
    public GameObject PausePanel;
    public GameObject iconscore;
    public SampleScene scene;
    public BonusScene Bscene;
    public Cirby afp;
    public GameObject win;

    //HUD
    public Text scoretext;
    static int score = 0;

    //Result
    public Text currentScoreText;
    public Text bestScoreText;
    public Text pauseScore;


    public Fryerz fry;
    public float speed;

    //pauseGame
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;


    public void start()
    {
        scoretext.text = score.ToString();
    }
    
    

    public void Pause()
    {
        pause();
        iconscore.SetActive(false);
        PausePanel.SetActive(true);
        pauseScore.text = score.ToString();
        afp.AfterPause();
    }
    
    public void resume()
    {
        Resume();
        iconscore.SetActive(true);
        PausePanel.SetActive(false);

    }

   void Resume()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void pause()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    

    public void IncreaseScore()
    {

        score++;
        scoretext.text = score.ToString();
        

        if(score == 10||score ==40||score ==70||score ==100||score ==130||score ==160||score ==190||score ==220||score ==250||score ==280||
        score ==310||score ==340||score ==370||score ==400||score ==430||score ==460||score ==490||score ==520||score ==550||score ==580||
        score ==610||score ==640||score ==670||score ==700||score ==730||score ==760||score ==790||score ==820||score ==850||score ==880||
        score ==910||score ==940||score ==970||score ==1000)
        {
            
            scene.LoadScene();

        }
        else if(score==1000)
        {
            pause();
            win.SetActive(true);
            resultPanel.SetActive(true);
            currentScoreText.text = score.ToString();

            int bestScore = PlayerPrefs.GetInt("BestScore");
            bestScoreText.text = bestScore.ToString();
            if(score>bestScore)
            {
              PlayerPrefs.SetInt("BestScore", score);
            
            }
        }
        
    }

    public void plusScore()
    {
        
        score++;
        scoretext.text = score.ToString();
        if(score == 30||score ==60||score ==90||score ==120||score ==150||score ==180||score ==210||score ==240||score ==270||score ==300||
        score ==330||score ==360||score ==390||score ==420||score ==450||score ==480||score ==510||score ==540||score ==570||score ==600||
        score ==630||score ==660||score ==690||score ==720||score ==750||score ==780||score ==810||score ==840||score ==870||score ==900||
        score ==930||score ==960||score ==990||score ==1020)
        {
            Bscene.LoadScene();

        }
        
        
    }

    public void EndGame()
    {
            
    }

    public void OneClick()
    {
        Resume();
   
    }

    public void ShowResult()
    {
        pause();
        hudPanel.SetActive(false);
        resultPanel.SetActive(true);
        pauseMenuUI.SetActive(false);
        currentScoreText.text = score.ToString();

        int bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = bestScore.ToString();
        if(score>bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            
        }
    }
    public void OnReplayClick()
    {
        score = 0;
        Resume();
        int level = Application.loadedLevel;
        Application.LoadLevel(level);
    }

    public void restart()
    {
        score = 0;
        Bscene.LoadScene();
    }

    void update()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        scoretext.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }
}
