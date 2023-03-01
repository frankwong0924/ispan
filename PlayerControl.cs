using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody pRigidBody;
    public float speed = 3;
    void Start()
    {
        pRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float cHorizontal = Input.GetAxis("Horizontal");
        float cVertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(-cHorizontal, 0, -cVertical);
        transform.Rotate(0.0f, cHorizontal, 0.0f, Space.Self);
        pRigidBody.velocity = direction * speed;
    }
}
