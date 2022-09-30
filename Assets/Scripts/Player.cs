using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] AudioClip sfxJump;
    [SerializeField] AudioClip sfxDeath;

    [SerializeField] float forceValue = 50f;
    private bool jump;
    private bool isDead;
    // Start is called before the first frame update
    private void Awake()
    {
            Assert.IsNotNull(sfxJump);
            Assert.IsNotNull(sfxDeath);
    }
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
            if(!isDead)
            {
            audioSource.PlayOneShot(sfxJump);
            animator.Play("Jump");
            jump = true;

            }

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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            isDead = true;
            audioSource.PlayOneShot(sfxDeath);
            rb.AddForce(new Vector2(50,20),ForceMode.Impulse);
            rb.detectCollisions = false;
        }
    }
}
