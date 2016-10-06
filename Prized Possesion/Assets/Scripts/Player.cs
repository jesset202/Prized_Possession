using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //Role
    public enum Role
    {
        Runner,
        Chaser
    }

    //Variables
    public float movSpeed   = 0;    //Movement speed
    public float jumpPower  = 0;    //Jump Power
    public float myPoints   = 0;    //Collecting coins
    public Role myRole;

    //Components
    private Rigidbody   myRigidbody;
    private Animator    myAnimator;
    private TrailRenderer myTrail;

    //Models
    public GameObject modelDagger;
    public GameObject modelSlash;

    //Controls
    public KeyCode jump;
    public KeyCode slide;

    //Start
	void Start ()
    {
        //init components
        myRigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponentInChildren<Animator>();
        myTrail = GetComponent<TrailRenderer>();

        //Disable models
        modelDagger.GetComponent<MeshRenderer>().enabled = false;
        modelSlash.GetComponent<MeshRenderer>().enabled = false;

        //Init variables
        myRole = Role.Runner;
        jump = KeyCode.W;
        slide = KeyCode.S;
    }
	
    //Update
	void Update ()
    {
        Controls();
    }

    //Controls
    void Controls()
    {
        //Auto-Run
        myRigidbody.velocity = new Vector3(1 * movSpeed, myRigidbody.velocity.y);

        //Jump
        if(Input.GetKeyDown(jump))
        {
            //myAnimator.SetTrigger("Jump");
            myRigidbody.velocity += Vector3.up * jumpPower;
        }

        //Slide
        if(Input.GetKeyDown(slide))
        {
            myAnimator.SetTrigger("Slide");
        }
        //change
    }

    //Check for obstacles/powerups/coins
    void OnTriggerEnter(Collider col)
    {
        //Check if hit coin
        if(col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            myPoints++;
        }

        //Check if hit speed powerUp
        if (col.gameObject.tag == "PowerUp_Speed")
        {
            Destroy(col.gameObject);
            StartCoroutine("PowerUp_Speed");
        }
    }


    //POWER UPS

    //Speed
    IEnumerator PowerUp_Speed()
    {
        float prevSpeed = movSpeed;
        movSpeed += 5f;
        yield return new WaitForSeconds(5f);
        movSpeed = prevSpeed;
    }
    
    //OBSTACLES

    //Slow
    IEnumerator Obstacle_Slow()
    {
        float prevSpeed = movSpeed;
        movSpeed -= 5f;
        yield return new WaitForSeconds(5f);
        movSpeed = prevSpeed;
    }

    //Stun
    IEnumerator Obstacle_Stun()
    {
        float prevSpeed = movSpeed;
        movSpeed = 0f;
        yield return new WaitForSeconds(5f);
        movSpeed = prevSpeed;
    }
}
