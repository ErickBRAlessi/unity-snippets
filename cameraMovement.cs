using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public GameObject player;
    public float cameraDistance;
    Vector3 distanceCompensate;
    // Start is called before the first frame update
    void Start()
    {
        distanceCompensate = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + distanceCompensate;
    }
}
