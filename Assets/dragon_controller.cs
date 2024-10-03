using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_controller : MonoBehaviour
{
    [SerializeField] private float speed;
    private FixedJoystick fixedjotstick;
    private Rigidbody rb;


    private void OnEnable()
    {
        fixedjotstick = FindObjectOfType<FixedJoystick>();
        rb = gameObject.GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        float xval = fixedjotstick.Horizontal;
        float yval = fixedjotstick.Vertical;
        Vector3 movement = new Vector3(xval, 0, yval);
        rb.velocity = movement * speed;
        
        if(xval != 0 && yval != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xval, yval) * Mathf.Rad2Deg, transform.eulerAngles.z);

        }
    }
}
