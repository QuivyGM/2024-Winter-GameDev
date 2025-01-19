using UnityEngine;

public class birdScript : MonoBehaviour
{
    public GameObject bird;
    public Rigidbody2D bird_rb;
    public float flapStrength;
    public float rotationSpeed=1f;
    public LogicScript logic;
    public bool birdIsAlive = true;

    AudioManager audioM;

    void Start() {
        // Access Game Logic
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        audioM = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        // Bird Jump
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
            bird_rb.linearVelocity = Vector2.up * flapStrength;
            // changing to += instead of = fails because gravity has bigger increase rate than flapStrength

            audioM.soundEffect(audioM.jump);
        }

        // Bird Rotation
        transform.rotation = Quaternion.Euler(0, 0, bird_rb.linearVelocity.y * rotationSpeed);
    }

    // Collision/Death Checker
    private void OnCollisionEnter2D(Collision2D collision) {
        logic.gameOver();
        birdIsAlive = false;
        audioM.soundEffect(audioM.hit);
        bird.GetComponent<CircleCollider2D>().enabled = false;
        bird_rb.linearVelocity = Vector2.up * 6;
        rotationSpeed = -30f;
        audioM.soundEffect(audioM.die);
    }
}
