using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    public float maxSpeed;
    bool movingLeft = true;
    bool firstInput = true;
 
    AudioSource music;
    public AudioClip Music;

    bool gameOver = false;

    public Rigidbody rb;
    public int jumpForce = 5;
    //public float distanceToCheck = 0.5f;
    bool isGrounded;
    bool jumpAllowed;
    bool turn;

    Vector2 startTouchPosition, endTouchPosition;

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
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
        // swipe check
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            /*
            if (touch.deltaPosition.y > 10f)
            {
                jumpAllowed = true;
                touch.deltaPosition = Vector2.zero;
            }
            */
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;
                if (endTouchPosition.y > startTouchPosition.y && touch.deltaPosition.y > 10f)
                    jumpAllowed = true;
            }
            
            if (touch.phase == TouchPhase.Ended && !jumpAllowed)
            {
                turn = true;
            }
        }

        /*
        if (endTouchPosition.y > startTouchPosition.y)
        {
            jumpAllowed = true;
            startTouchPosition = Vector2.zero;
            endTouchPosition = Vector2.zero;
        }
        */
    }
    /*
    void swipeCheck()
    {
        // swipe check
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;
                if (endTouchPosition.y > startTouchPosition.y)
                    jumpAllowed = true;
            }

            if (touch.phase == TouchPhase.Ended && !jumpAllowed)
            {
                turn = true;
            }

        }
    }
    */
    public void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        if(moveSpeed < maxSpeed)
        {
            moveSpeed += 0.2f * Time.deltaTime;
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
        turn = false;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        music.PlayOneShot(Music, 0.4f);
        jumpAllowed = false;
    }

    void checkInput()
    {
        // ilk tiklama ile yon degistirmeye baslamamasi icin, ilk tiklamayi ignoreluyoruz. Cunku ilk tiklamada menu bolumunden oyuna gececegiz.
        
        if(firstInput)
        {
            firstInput = false;
            return;
        }

        if (turn == true && jumpAllowed == false)
        {
            changeDirection();

        }
        
        if (Input.GetKeyDown(KeyCode.W) && jumpAllowed == false)
        {
            changeDirection();
        }
        
        //jumping

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            Jump();
        }

        if (isGrounded == true && jumpAllowed == true)
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
