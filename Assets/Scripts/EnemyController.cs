using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public GameObject projectile;
    public Transform projectileSpawn;
    
    private float nextActionTime = 2f;
    public float period = 0.1f;

    public float begin;
    public float dist = 5; 
    public float speed = 5;
    public int dir;


    void Start()
    {
        begin = transform.position.x;
        dir = 1;
    }


    void Update()
    {
        if (transform.position.x > begin + dist)
        {
            dir = -1;
        } else if(transform.position.x < begin-dist) {
            dir = 1;
        }

        var position = transform.position;
        position = new Vector3(position.x + Time.deltaTime * speed * dir, position.y, position.z);
        
        transform.position = position;

        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
