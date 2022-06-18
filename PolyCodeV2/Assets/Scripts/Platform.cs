using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject Star;
    public GameObject Cuboid;

    // Start is called before the first frame update
    void Start()
    {
        // platforda yildizlarin ne kadar aralikla cikacagini burdan ayarliyoruz. Mesela range kismini (0,1) yapsam daha cok cikacak, (0,20) yaparsam cok nadir cikacak
        int RandomStar = Random.Range(0, 7);
        int RandomCuboid = Random.Range(0, 12);

        float[] heightList = { 1f, 2.5f };
        float RandomPosition = heightList[Random.Range(0, 2)];

        Vector3 starPosition = transform.position;
        starPosition.y += RandomPosition;

        Vector3 CuboidPosition = transform.position;
        CuboidPosition.y += RandomPosition;

        if (RandomStar < 1)
        {
            //platforma yildiz cikar
            GameObject StarInstance =   Instantiate(Star, starPosition, Star.transform.rotation);
          
            StarInstance.transform.SetParent(gameObject.transform); 
        }

        if (RandomCuboid < 1)
        {
            GameObject CuboidInstance = Instantiate(Cuboid, CuboidPosition, Cuboid.transform.rotation);

            CuboidInstance.transform.SetParent(gameObject.transform);
        }
    }

    void PlatformDusme()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }

    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Invoke("PlatformDusme", 0.5f);
        }
    }
}
