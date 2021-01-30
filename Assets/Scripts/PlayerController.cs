using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.5f;
    public float rotational_speed = 3f;

    Rigidbody rb;
    public Animator anim;

    public bool canMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (Mathf.Abs(y) > 0.1f && canMove)
        {
            anim.SetBool("walking", true);
            transform.position += transform.forward * y * speed * Time.deltaTime;
        }
        else
        {
            anim.SetBool("walking", false);
        }
        if(Mathf.Abs(x) > 0.1f && canMove)
        {
            transform.Rotate(Vector3.up * x * rotational_speed * Time.deltaTime);
        }
    }
}
