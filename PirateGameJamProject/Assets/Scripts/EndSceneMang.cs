using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneMang : MonoBehaviour
{
    public GameObject stuff;

    public float counter;
    public bool clicked = false;
    public float muti;
    public bool go;
    public GameObject image;
    public Text highscoreText;
    public GameObject NewHighScoreText;

    public void Start()
    {
        go = true;
        Cursor.visible = true;
        if(FindObjectOfType<ScoreThing>().newScore == true)
        {
            NewHighScoreText.SetActive(true);
        }
        highscoreText.text = "Final Score: " + FindObjectOfType<ScoreThing>().score.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        if(go == true)
        {
            image.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (image.GetComponent<CanvasGroup>().alpha <= 0f)
            {
                go = false;
                image.SetActive(false);
            }
        }
        if (clicked == true)
        {
            counter -= muti * Time.deltaTime;
            stuff.GetComponent<CanvasGroup>().alpha = counter;
            if (counter <= 0f)
            {
                Invoke("Change", 1.5f);
            }
        } 
    }

    public void GotClicked()
    {
        clicked = true;
    }


    public void Change()
    {
        FindObjectOfType<ScoreThing>().newScore = false;
        NewHighScoreText.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
