using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Vector3 position;
    public CharacterController CharacterController;
    // private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        // anim = GetComponent<Animator>();
        position = new Vector3(transform.position.x, 0, transform.position.z);;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            locatePosition();
        }
        moveToPosition();
    }

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
    }

    void moveToPosition()
    {
        // anim.SetInteger("Walk", 0);
        if (Vector3.Distance(transform.position, position) > 1.156f)
        {
            // anim.SetInteger("Walk", 1);
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);
            newRotation.x = 0;
            newRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);

            CharacterController.SimpleMove(transform.forward * speed);
        }
    }
}
