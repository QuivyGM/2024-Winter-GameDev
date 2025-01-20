using UnityEngine;

public class ballScript : MonoBehaviour
{
    public float ballSpeedX;
    public float ballSpeedY;
    public GameObject paddle1;
    public GameObject paddle2;

    public logicManager logic;
    private float bAngle = 10f;

    AudioManager audioM;

    void Start() {
        Reset();
        ballSpeedX = OptionScript.ballspeed;
        Debug.Log($"Ballspeed is {ballSpeedX}");
        audioM = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update() {
        transform.position += new Vector3( ballSpeedX * Time.deltaTime, ballSpeedY * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        audioM.bounce_sound();

        // change ball movement direction based on wall bounced
        if (collision.gameObject.layer == 6) { // paddle layer
            ballSpeedX *= -1;

            if(ballSpeedX < 0)
                ballSpeedY = (transform.position.y - paddle2.transform.position.y) * bAngle;
            else
                ballSpeedY = (transform.position.y - paddle1.transform.position.y) * bAngle;
        }
        else    // wall layer
            ballSpeedY *= -1;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
        // update score based on ball direction
        if (ballSpeedX > 0)
            logic.addScore1();
        else
            logic.addScore2();


        Reset();
    }

    // reset ball position and y velocity
    private void Reset() {
        transform.position = new Vector3(0, 0, 0);
        ballSpeedX *= -1;
        ballSpeedY = 0;
    }
}
