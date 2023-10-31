using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Vector3 lineDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = planet.transform.position - transform.position;
        moveDir = new Vector3(gravityDir.y, gravityDir.x * -1, 0f);
        moveDir = moveDir.normalized * -1f;
        lineDir = new Vector3(0f, -2f, 0f);

        rb.AddForce(moveDir * force);

        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(lineDir, gravityDir, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(0f, 0f, angle));
        
        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
        DebugExtension.DebugArrow(Vector3.zero, lineDir, Color.black);
        
    }
}


