using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Vector3 = UnityEngine.Vector3;

public class DragAndThrow : MonoBehaviour
{

    private Rigidbody rigidbody;
    public List<Vector3> listOfPositions = new List<Vector3>();
    private Vector3 currentPosition;
    private Collider groundCollider;
    public GameObject ground;
    public int captureFrames = 8;
    public float throwPower = 5;
    public float maxMagnitude = 10;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        groundCollider = ground.GetComponent<Collider>();
    }

    void OnMouseDown()
    {
        readPosition();
        transform.position = transform.position + new Vector3(0, 1, 0);
        rigidbody.useGravity = false;
        listOfPositions.Add(currentPosition);
        rigidbody.velocity = rigidbody.angularVelocity = Vector3.zero;
    }


    void OnMouseDrag()
    { 
        readPosition();
        if (listOfPositions.Count >= captureFrames)
        {
            listOfPositions.RemoveAt(0);
            listOfPositions.TrimExcess();
        }
    }

    void OnMouseUp()
    {
        rigidbody.useGravity = true;
        var oldPosition = listOfPositions[0];
        var forceMagnitude = (oldPosition - transform.position).magnitude;
        var forceDirection = (oldPosition - transform.position).normalized;
        float newMagnitude = Mathf.Min(forceMagnitude, maxMagnitude);
        rigidbody.AddForce(forceDirection * -newMagnitude * throwPower, ForceMode.Impulse);
        listOfPositions.Clear();
    }

    void readPosition()
    {
        RaycastHit hit;
        if (groundCollider.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200.0F))
        {
            currentPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.position = currentPosition;
        }
        listOfPositions.Add(currentPosition);
    }
}
 

