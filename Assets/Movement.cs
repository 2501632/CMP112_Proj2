using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    float hInput;
    float vInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        vInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
    }
}
