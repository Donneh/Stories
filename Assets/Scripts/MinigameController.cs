using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MinigameController : MonoBehaviour
{
    public float movementSpeed = 6f;

    public GameObject projectile;
    public Transform projectileSpawn;
    public float fireRate = 0.5f;
    private float lastShot = 0.0f;

    private Vector3 mousePosition;
    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Shoot();
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000))
            {
                mousePosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }

            Vector3 moveDir = Vector3.zero;
            if (mousePosition.x < transform.position.x)
            {
                moveDir.x = -1;
            }
            else
            {
                moveDir.x = 1;
            }
            transform.position += moveDir * (movementSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        if (Time.time > fireRate + lastShot)
        {
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            lastShot = Time.time;
        }
    }
}
