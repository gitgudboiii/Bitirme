using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gamestarted;
    public GameObject PlatformSpawner;
    public Text Skor;
    public GameObject SkorUI;
    public GameObject AnaMenu;
    public Text text4;
    AudioSource music;
    public AudioClip[] Music;

    public Button Button;
    public GameObject button;
    public GameObject buttonStart;

    int score = 0;
    int highestScore;
    int adCounter = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        music = GetComponent<AudioSource>();
        Button = button.GetComponent<Button>();
        
    }



    // Start is called before the first frame update
    void Start()
    {
        highestScore = PlayerPrefs.GetInt("HighestScore");
        text4.text = "YOUR HIGHEST SCORE : " + highestScore;

        CheckAdCount();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!gamestarted)
        {
            
            if (buttonStart.)
            {
                LoadScene();
            }
            
            if (Button.buttonPressed) //Input.GetMouseButtonDown(0)
            {
                GameStart();
            }
        }
        */
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("SelectCar");
    }

    public void GameStart()
    {
        gamestarted = true;
        PlatformSpawner.SetActive(true);
        AnaMenu.SetActive(false);
        SkorUI.SetActive(true);
        button.SetActive(false);

        //muzik oynatma
        music.clip = Music[1];
        music.Play();

        StartCoroutine("UpdateScore");    
    }

    public void GameOver()
    {
        PlatformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        HighestScore();

        //showad

       //AdsManager.instance.ShowAd();
        
        if(adCounter >= 3)
        {
            adCounter = 0;
            PlayerPrefs.SetInt("AdCount", 0);

            AdsManager.instance.ShowRewardedAd();
        }
        else
        {
            Invoke("LevelReload", 1f);
        }
        //Invoke("LevelReload", 1f);
    }

    public void LevelReload()
    { 
        SceneManager.LoadScene("GamePlatform");
    }

    void HighestScore()
    {
        if(PlayerPrefs.HasKey("HighestScore"))
        {
            //en yuksek skorumuz daha onceden oldugunda
            if(score > PlayerPrefs.GetInt("HighestScore"))
            {
                PlayerPrefs.SetInt("HighestScore",score);
            }

        }
        else
        {
            // Oyunu ilk defa oynarken, en yuksek skorumuz olmadiginda.
            PlayerPrefs.SetInt("HighestScore", score);
        }
    }

    public void SkoruArttir(bool star)
    {
        if (star)
        {
            score += 10;
            music.PlayOneShot(Music[2], 0.4f);
        }
        else
        {
            score -= 10;
            music.PlayOneShot(Music[3], 0.4f);
        }

        
    }


    IEnumerator UpdateScore()
    {
        //sonsuz bir dongu olusturmak icin bu yontemi kullaniyorum.  yani while(true) infinite bir dongu yaratmakta.
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            score++;
            
            Skor.text = score.ToString();
        }
    }

    void CheckAdCount()
    {
        if(PlayerPrefs.HasKey("AdCount"))
        {
            adCounter = PlayerPrefs.GetInt("AdCount");
            adCounter++;

            PlayerPrefs.SetInt("AdCount", adCounter);

        }
        else
        {
            PlayerPrefs.SetInt("AdCount", 0);
        }
    }



}
