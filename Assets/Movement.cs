using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    float hInput;
    float vInput;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnMove(InputValue moveValue)
    {
        Vector2 moveVector = moveValue.Get<Vector2>();

        hInput = moveVector.x;
        vInput = moveVector.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(hInput, 0.0f, vInput);
        rb.AddForce(move * moveSpeed);

        if (rb.linearVelocity.magnitude > moveSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * moveSpeed;
    }
}
