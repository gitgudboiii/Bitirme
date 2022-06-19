using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    //public bool buttonPressed = false;
    public GameManager gameManager;
    
    /*
    public void OnPointerDown()
    {
        buttonPressed = true;
    }
    */
    public void OnStartButtonClicked()
    {
        gameManager.GameStart();
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void onSelectButtonClicked()
    {
        SceneManager.LoadScene("SelectCar");
    }
    /*
    public void LoadScene()
    {
        SceneManager.LoadScene("SelectCar");
    }
    */
}
