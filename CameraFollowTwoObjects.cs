﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTwoObjects : MonoBehaviour
{

    public GameObject FirstFollowedObject;
    public GameObject SecondFollowedObject;
    public float Margin;

    private Transform player1;
    private Transform player2;

    private Vector3 middlePoint;
    private float distanceFromMiddlePoint;
    private float distanceBetweenPlayers;
    private float cameraDistance;
    private float aspectRatio;
    private float fov;
    private float tanFov;

    void Start()
    {
        player1 = FirstFollowedObject.transform;
        player2 = SecondFollowedObject.transform;
        aspectRatio = Screen.width / Screen.height;
        tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);
    }

    void Update()
    {

        // Position the camera in the center.
        Vector3 newCameraPos = Camera.main.transform.position;
        newCameraPos.x = middlePoint.x;
        Camera.main.transform.position = newCameraPos;

        // Find the middle point between players.
        Vector3 vectorBetweenPlayers = player2.position - player1.position;
        middlePoint = player1.position + 0.5f * vectorBetweenPlayers;

        // Calculate the new distance.
        distanceBetweenPlayers = vectorBetweenPlayers.magnitude;
        cameraDistance = (distanceBetweenPlayers / 2.0f / aspectRatio) / tanFov;

        // Set camera to new position.
        Vector3 dir = (Camera.main.transform.position - middlePoint).normalized;
        Camera.main.transform.position = middlePoint + dir * (cameraDistance + Margin);
    }
}
