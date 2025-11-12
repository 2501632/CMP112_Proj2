using UnityEngine;

public class Fall : MonoBehaviour
{
    public GameObject player;
    public GameObject tpPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in here");
            player.transform.position = tpPoint.transform.position;
        }            
    }


    
}
