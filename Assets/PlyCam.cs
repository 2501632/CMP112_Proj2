using UnityEngine;

public class PlyCam : MonoBehaviour
{
    public float sensY = 150f, sensX = 100f;
    float mouseY, mouseX;
    float lookY, lookX;

    Transform ornt;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        lookY += mouseX;
        lookX -= mouseY;
        lookX = Mathf.Clamp(lookX, -90, 90);

        transform.rotation = Quaternion.Euler(lookX, lookY, 0);
        ornt.rotation = Quaternion.Euler(0, lookY, 0);
    }
}
