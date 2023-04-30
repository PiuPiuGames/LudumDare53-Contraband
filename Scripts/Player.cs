using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float angle;
    public float bankAngle;

    private float throttle;
    private float bank;

    public float ThrottlePitchOffset;
    public float ThrottlePitchMulti;

    private Rigidbody2D RB;
    private AudioSource AS;
    private Animator anim;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.W))
            throttle = 10f * speed;  
        else if (Input.GetKey(KeyCode.S))
            throttle = 0f;
        else
            throttle = 9.8f;
        if (Input.GetKey(KeyCode.A))
        {
            bank = Mathf.Lerp(bank, -angle, Time.deltaTime);
            anim.SetBool("Left", false);
            anim.SetBool("Right", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            bank = Mathf.Lerp(bank, angle, Time.deltaTime);
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);
        }
        else
        {
            bank = Mathf.Lerp(bank, 0, Time.deltaTime);
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
        }
        transform.eulerAngles = Vector2.right * bank;
        AS.pitch = throttle * ThrottlePitchMulti + ThrottlePitchOffset;
        AS.panStereo = -bank / 10;
        if (transform.childCount != 0)
            RB.mass = 1 + GetComponentInChildren<package>().weight;
    }
    private void FixedUpdate() {
        RB.AddRelativeForce(new Vector2(bank, throttle));        
    }
}
