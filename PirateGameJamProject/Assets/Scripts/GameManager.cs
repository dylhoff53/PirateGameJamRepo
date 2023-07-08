using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject image;
    public bool go;
    public AudioSource camAudioSource;
    public int audioCounter;
    public AudioSource camAudioSource2;
    public AudioSource camAudioSource3;
    public float audioMuti;
    public int lastDeathSound;
    public float EndTimer;
    public GameObject endText;
    public ScoreThing scoreThing;

    private void Start()
    {
        Invoke("Begin", 3.0f);
       // AudioSwitch();
        camAudioSource.Play();
        Invoke("AudioSwitch", camAudioSource.clip.length - 1.5f);
        camAudioSource2.PlayDelayed(camAudioSource.clip.length - 1.5f);
        Invoke("AudioSwitch", camAudioSource.clip.length + camAudioSource2.clip.length - 1.5f);
        camAudioSource3.PlayDelayed(camAudioSource.clip.length + camAudioSource2.clip.length - 1.5f);
        Cursor.visible = false;
    }
    public void AudioSwitch()
    {
        audioCounter++;
    }


    public void Begin()
    {
        go = true;
    }

    // Update is called once per frame
    void Update()
    {
        EndTimer -= Time.deltaTime;
        if (EndTimer <= 0f)
        {
            endText.SetActive(true);
            image.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
            Invoke("GameOver", 3.0f);
        }
        if (go == true)

        {
            image.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (image.GetComponent<CanvasGroup>().alpha <= 0f)
            {
                go = false;
            }
        }
        if (audioCounter == 1)
        {
            camAudioSource.volume -= audioMuti * Time.deltaTime;
            if(camAudioSource2.volume < 0.2f)
            {
                camAudioSource2.volume += audioMuti * Time.deltaTime;
            }

        } else if (audioCounter == 2)
        {
            camAudioSource2.volume -= audioMuti * Time.deltaTime;
            if (camAudioSource3.volume < 0.2f)
            {
                camAudioSource3.volume += audioMuti * Time.deltaTime;
            }
        }
    }

    public void addScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString("0");
    }

    public void GameOver()
    {
        scoreThing.SaveScore();
        SceneManager.LoadScene(2);
    }
}
