using UnityEngine;

public class BirdScript : MonoBehaviour
{
    //references that can be accessed/modified from unity
    public Rigidbody2D myRigidbody;     // gives vs(and unity?) access to values from rigidbody2d
    public float flapStrength;          // gives unity a way to change value without constantly returning to vs -> can change values while sim is running
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true) //Input.GetKeyDown(KeyCode.Space) && birdIsAlive
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;  //Vector2.up == (0,1) -> changes velocity to move towards (0,1) of current position
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
