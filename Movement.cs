using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float rotateSpeed = 150f;
    [SerializeField] float thrust = 1000f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
    }
    
    void ProcessRotation()
    {
         if(Input.GetKey(KeyCode.A))
        {
            Rotate(rotateSpeed);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            Rotate(-rotateSpeed);
        }
    }

    public void Rotate(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation to manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreeze
    }
}
