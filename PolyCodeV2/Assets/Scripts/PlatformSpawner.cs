using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPosition;

    bool stop;

    private Vector3 scaleChange;
    //float timer = 0;
    float scale = 2f;
    int platformCountX = 0;
    int platformCountZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;

        StartCoroutine(SpawnPlatforms());

        scaleChange = new Vector3(1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnPlatforms()
    {
        while(!stop)
        {
            /*
            if (timer > 5)
            {
                platform.transform.localScale -= scaleChange;
                scale -= 1f;
                timer = 0;
            }
            
            timer += Time.deltaTime;
            */

            GeneratePosition();

            Instantiate(platform, newPosition, Quaternion.identity);

            lastPosition = newPosition; 

            yield return new WaitForSeconds(0.1f);
        }
        
    }

    //void SpawnPlatforms()
    //{
      //  GeneratePosition();

        //Instantiate(platform, newPosition, Quaternion.identity);

        //lastPosition = newPosition;
    //}

    void GeneratePosition()
    {
        newPosition = lastPosition;

        int randomGap = Random.Range(5, 10);
        int random = Random.Range(0, 2);

        if (platformCountX > randomGap)
        {
            newPosition.x += scale;
            platformCountX = 0;
            random = 1;
        }
        if (platformCountZ > randomGap)
        {
            newPosition.z += scale;
            platformCountZ = 0;
            random = 0;
        }

        if (random > 0)
        {
            newPosition.x += scale;
            platformCountX++;
        }
        else
        {
            newPosition.z += scale;
            platformCountZ++;
        }


    }
}
