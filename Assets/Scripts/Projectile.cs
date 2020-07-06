using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifespan = 3f;
    public float knockbackSpeed = 100f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(rb.transform.forward * speed);
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        Rigidbody orb = other.GetComponent<Rigidbody>();
        orb.AddForce(transform.forward * knockbackSpeed); 
        Destroy(gameObject);
    }
}
