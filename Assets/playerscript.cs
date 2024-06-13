using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class playerscript : MonoBehaviour
{
    public Rigidbody rb;
    private bool isBlock = true;
    private AudioSource audioSource;
    public GameObject bombParticle;
    public Animator Animator;
    // Start is called before the first frame upda1te
    void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        float moveSpeed = 3;
        float jump = 7;
        float distance = 0.9f;
        float stick = Input.GetAxis("Horizontal");
        //Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
        isBlock = Physics.Raycast(ray, distance);

        if (Input.GetKey(KeyCode.RightArrow)||stick>0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            v.x = moveSpeed;
            Animator.SetBool("mode", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)||stick<0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            v.x = -moveSpeed;
            Animator.SetBool("mode", true);
        }
        else
        {
            v.x = 0;
            Animator.SetBool("mode", false);
        }
       
        if (Input.GetButtonDown("Jump"))
        {
            v.y = jump;
        }

        rb.velocity = v;

        if (isBlock == true)
        {
            Animator.SetBool("isjump", false);
        }
        else
        {
            Animator.SetBool("isjump", true);
        }
        Debug.Log(v);

        if(isBlock == true)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
        }
        else
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
            Instantiate(bombParticle, transform.position, Quaternion.identity);

        }
    }
}
