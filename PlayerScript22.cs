using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//&& = and == = same as != not the same as || = or 
public class PlayerScript22 : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    public float moveSpeed;

    private bool facingRight;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    private float jumpForce;

    private Animator myAnimator;

    public bool isAlive;

    public GameObject reset;

    private Slider healthbar;

    public float health = 3f;

    private float healthBurn = 1f;

    public GameObject nextButton;


    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();   //a variable to control the players body 
        myAnimator = GetComponent<Animator>();
        reset.SetActive(false);
        healthbar = GameObject.Find("health slider").GetComponent<Slider>();
        healthbar.minValue = 0f;
        healthbar.maxValue = health;
        healthbar.value = healthbar.maxValue;
        nextButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()

    {
        float horizontal = Input.GetAxis("Horizontal");       // a variable that stores value of horizontal movement 
        //Debug.Log(horizontal);
        if (isAlive)
        {
            PlayerMovement(horizontal);     // function that controls player on x axis
            Flip(horizontal);
            HandleInput();            
        }
        isGrounded = IsGrounded();
    }

    //Function Definitions
    // function that controls player on x axis
    private void PlayerMovement(float horizontal)
    {
        if(isGrounded && jump)
        {
            isGrounded = false;
            jump = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
        }
        myRigidbody.velocity = new Vector2(horizontal * moveSpeed, myRigidbody.velocity.y); // adds velocity to the players body on the x axis 
        myAnimator.SetFloat("Speed",Mathf.Abs(horizontal));
       
    }

    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
       myAnimator.SetBool("Jumping", !isGrounded);
    }

    private void Flip(float horizontal)
    {
        if (horizontal<0 && facingRight || horizontal>=0 && !facingRight)
        {
            facingRight = !facingRight; //resets the bool to the opposite 
            Vector2 theScale = transform.localScale;
            theScale.x *=- 1;
            transform.localScale = theScale; //creating a vector2 and storing the local scale values 
        }
    }

    //function to test for collisions between the array of groundPoints and the Ground LayerMask

    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            //if the player is not moving vertically, test each of the Player's groundPoints for collision with Ground
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; 1 < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject) //if any of the colliders in the array of groundPoints comes into contact with another gameobject, return true.
                    {
                        return true;
                      
                    }
                }
            }
        }
        return false; //if the player is not moving along the y axis, return false.
    }
    void OnCollisionEnter2D (Collision2D target)
    {
        if(target.gameObject.tag == "deadly")
        {
            ImDead();
        }
        if (target.gameObject.tag == "damaging")
        {
            UpdateHealth();
        }
    }

    void UpdateHealth()
    {
        if (health > 0)
        {
            health -= healthBurn; //health = health - healthBurn
            healthbar.value = health;
        }
        if (health <= 0)
        {
            ImDead();
        }
    }
    public void ImDead()
    {

        isAlive = false;
        myAnimator.SetBool("Dead", true);
        reset.SetActive(true);
        healthbar.value = 0;
    }
}
