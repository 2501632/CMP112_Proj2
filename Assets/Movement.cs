using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float gravMult;
    float hInput;
    float vInput;
    public Rigidbody rb;
    public LayerMask groundLayer;
    public float groundDistance;
    bool grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        }

        if (rb.linearVelocity.y <= 0f)
        {
            rb.AddForce(Vector3.down * gravMult, ForceMode.Force);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(hInput, 0.0f, vInput);
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundDistance);
    }

}
