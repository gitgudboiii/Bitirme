using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    public float maxSpeed;
    bool movingLeft = true;
    bool firstInput = true;

    bool gameOver = false;

    public Rigidbody rb;
    public int jumpForce = 5;
    //public float distanceToCheck = 0.5f;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gamestarted)
        {
             Move();
             checkInput();
        }

        if(transform.position.y <= -2)
        {
            if(!gameOver)
            {
                gameOver = true;

                GameManager.instance.GameOver();
            }
    
        }


    }

    public void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        if(moveSpeed < maxSpeed)
        {
            moveSpeed += 0.1f * Time.deltaTime;
        }
    }

    void changeDirection()
    {
        if(movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else{
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void checkInput()
    {
        // ilk tiklama ile yon degistirmeye baslamamasi icin, ilk tiklamayi ignoreluyoruz. Cunku ilk tiklamada menu bolumunden oyuna gececegiz.
        if(firstInput)
        {
            firstInput = false;
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            changeDirection();
        }
        //jumping
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Star")
        {
            GameManager.instance.SkoruArttir(true);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Cuboid")
        {
            GameManager.instance.SkoruArttir(false);
            other.gameObject.SetActive(false);
        }
    }




}
