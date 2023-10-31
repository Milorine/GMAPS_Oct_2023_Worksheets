using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
       //OtherPlayers = FindObjectsOfType<SoccerPlayer>();
       //SoccerPlayer[] temp = new SoccerPlayer[OtherPlayers.Length - 1];
       //int i = 0;
       //foreach (SoccerPlayer p in OtherPlayers)
       //{
        //if (p != this)
        //{
            //temp[i] = p;
            //i++;
        //}
       //}
       //OtherPlayers = temp;
    }

    //float Magnitude(Vector3 vector)
    //{
        
    //}

    //Vector3 Normalise(Vector3 vector)
    //{
        
    //}

    //float Dot(Vector3 vectorA, Vector3 vectorB)
    //{
        
    //}

    //SoccerPlayer FindClosestPlayerDot()
    //{
    //    SoccerPlayer closest = null;

    //    return closest;
    //}

    //void DrawVectors()
    //{
    //    foreach (SoccerPlayer other in OtherPlayers)
    //    {
    //        // Your code here
    //        // ...
    //    }
    //}

    void Update()
    {
        DebugExtension.DebugArrow(transform.position, transform.forward, Color.red);

        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
        }
    }
}


