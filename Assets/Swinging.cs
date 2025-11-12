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
            StartSwing();
        if (Input.GetKeyUp(KeyCode.Mouse0)) 
            EndSwing();
    }

    void LateUpdate()
    {
        DrawRope();
    }

    void StartSwing()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxSwingDistance, attachable))
        {
            swingPoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = swingPoint;

            float distanceFromPoint = Vector3.Distance(player.position, swingPoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
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

        currentGrapplePos = Vector3.Lerp(currentGrapplePos, swingPoint, Time.deltaTime * 8f);

        lr.SetPosition(0, ropeLauncher.position);
        lr.SetPosition(1, swingPoint);
    }
}
