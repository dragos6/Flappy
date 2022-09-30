using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] AudioClip sfxJump;
    [SerializeField] AudioClip sfxDeath;

    [SerializeField] float forceValue = 50f;
    private bool jump;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(sfxJump);
            animator.Play("Jump");
            jump = true;

        }
    }

    private void FixedUpdate()
    {
        if(jump)
        {
            jump = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, forceValue),ForceMode.Impulse);
        }
    }
}
