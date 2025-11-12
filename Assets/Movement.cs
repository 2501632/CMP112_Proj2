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

    public GameObject cameraObj;
    public float sensY = 150f, sensX = 100f;
    float mouseY, mouseX;
    float lookY, lookX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(hInput, 0.0f, vInput);
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);


        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        lookY += mouseX;
        lookX -= mouseY;
        lookX = Mathf.Clamp(lookX, -90, 90);

        cameraObj.transform.rotation = Quaternion.Euler(lookX, lookY, 0);
        transform.rotation = Quaternion.Euler(0, lookY, 0);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundDistance);
    }

}
