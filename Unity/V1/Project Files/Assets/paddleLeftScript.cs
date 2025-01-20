using UnityEngine;
using UnityEngine.InputSystem;

public class paddleLeftScript : MonoBehaviour {

    private float moveInput;
    private Rigidbody2D rb;
    float speed = 5f;

    private InputMap input;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        input = new InputMap();
        input.PaddleInput.Enable();
        input.PaddleInput.leftUp.performed += ctx => moveInput = 1f;
        input.PaddleInput.leftUp.canceled += ctx => moveInput = 0f;

        input.PaddleInput.leftDown.performed += ctx => moveInput = -1f;
        input.PaddleInput.leftDown.canceled += ctx => moveInput = 0f;
    }

    private void OnDisable() {
        input.PaddleInput.leftUp.performed -= ctx => moveInput = 1f;
        input.PaddleInput.leftUp.canceled -= ctx => moveInput = 0f;

        input.PaddleInput.leftDown.performed -= ctx => moveInput = -1f;
        input.PaddleInput.leftDown.canceled -= ctx => moveInput = 0f;
    }

    private void Update() {
        rb.linearVelocity = new Vector2(0, moveInput * speed);

        Vector2 clampedPosition = rb.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.2f, 4.2f);
        rb.position = clampedPosition;
    }
}
