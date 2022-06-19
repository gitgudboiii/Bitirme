using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSellector : MonoBehaviour
{
    public int CurrentCarIndex;
    public GameObject[] cars;

    // Start is called before the first frame update
    void Start()
    {

        CurrentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);
        foreach(GameObject car in cars)
            car.SetActive(false);

        cars[CurrentCarIndex].SetActive(true);

    }
}
