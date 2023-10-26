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

        rb.AddForce(moveDir * force);

        gravityNorm = gravityDir.normalized;
        rb.AddForce(gravityNorm * gravityStrength);

        float angle = Vector3.SignedAngle(gravityDir, moveDir, Vector3.forward);

        rb.MoveRotation(Quaternion.Euler(angle, 0f, 0f));
        
        DebugExtension.DebugArrow(Vector3.zero, gravityDir, Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, moveDir, Color.blue, 60f);
        
    }
}


