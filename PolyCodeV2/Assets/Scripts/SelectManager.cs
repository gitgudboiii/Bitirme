using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public int CurrentCarIndex;
    public GameObject[] carModels;
    // Start is called before the first frame update
    void Start()
    {
        CurrentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);
        foreach(GameObject car in carModels)
            car.SetActive(false);



        carModels[CurrentCarIndex].SetActive(true);   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeNext()
    {
        carModels[CurrentCarIndex].SetActive(false);

        CurrentCarIndex++;
        if(CurrentCarIndex==carModels.Length)
           CurrentCarIndex = 0;


        carModels[CurrentCarIndex].SetActive(true); 
        PlayerPrefs.SetInt("SelectedCar", CurrentCarIndex);  
    }

    public void ChangePrevious()
    {
        carModels[CurrentCarIndex].SetActive(false);

        CurrentCarIndex--;
        if(CurrentCarIndex== -1)
           CurrentCarIndex = carModels.Length -1;


        carModels[CurrentCarIndex].SetActive(true); 
        PlayerPrefs.SetInt("SelectedCar", CurrentCarIndex);  
    }
}
