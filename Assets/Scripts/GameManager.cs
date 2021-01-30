using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public bool tracking = false;
    public bool Ended = false;

    public float Timer = 5f;

    public Text timerText;

    public int NextLevel;

    public GameObject retrybutton;
    public GameObject nextbutton;

    void Update()
    {
        if (tracking)
        {
            timerText.gameObject.SetActive(true);
            timerText.color = new Color(1f, .5f, .5f);
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                Timer = 0;
                FindObjectOfType<PlayerController>().canMove = false;
                timerText.text = "911 called, you were caught...";
                retrybutton.SetActive(true);
                Debug.Log("Caught");
                return;
            }
            timerText.text = "Calling 911 in " + "0" + ((int)Timer).ToString() + ":" + ((int)((Timer - (int)Timer) * 100)).ToString();
        }
        else
        {
            if (timerText && !Ended)
            {
                timerText.color = new Color(.9f, .9f, .9f);
                timerText.text = "Gone out for coffee...";
            }
            Timer = 5f;
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
