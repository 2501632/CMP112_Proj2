using UnityEngine;

public class Swinging : MonoBehaviour
{
    public LineRenderer lr;
    public LayerMask attachable;
    public Transform cam, player, ropeLauncher;

    public float maxSwingDistance;
    Vector3 anchorPoint;
    SpringJoint joint;
    Vector3 currentGrapplePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Swing();
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
            EndSwing();
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void Swing()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxSwingDistance, attachable))
        {
            anchorPoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = anchorPoint;

            float distanceFromPoint = Vector3.Distance(player.position, anchorPoint);

            joint.maxDistance = distanceFromPoint * 0.3f;
            joint.minDistance = distanceFromPoint * 0.15f;

            joint.spring = 10f;
            joint.damper = 5f;
            joint.massScale = 4.5f;


            lr.positionCount = 2;
        }
    }

    void EndSwing()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    void DrawRope()
    {
        if (!joint)
            return;


        lr.SetPosition(0, ropeLauncher.position);
        lr.SetPosition(1, anchorPoint);
    }
}
