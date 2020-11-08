using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

       direction  = new Vector3(eixoX, 0, eixoZ);
/*
        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }
*/
    }

    void FixedUpdate()
    {
        Debug.Log(direction * speed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(
            (GetComponent<Rigidbody>().position +
            (direction * speed * Time.deltaTime)));
    }
}
