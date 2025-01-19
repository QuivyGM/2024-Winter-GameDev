using UnityEngine;

public class pipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float deadZone = -11f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (transform.position.x < deadZone) {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
