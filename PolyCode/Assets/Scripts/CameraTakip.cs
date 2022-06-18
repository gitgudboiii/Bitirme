using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTakip : MonoBehaviour
{


    public Transform targets;
    Vector3 distance;
    public float sValue;

    // Start is called before the first frame update
    void Start()
    {

        distance = targets.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targets.position.y  >=0)
        {
            Takip();
        }
        
    }


    void Takip()
    {
        Vector3 currentPos = transform.position;

        Vector3 targetPos = targets.position - distance;

        transform.position = Vector3.Lerp(currentPos, targetPos, sValue * Time.deltaTime);
    }
}
