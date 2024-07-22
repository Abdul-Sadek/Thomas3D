using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    PlayerData playerData;

    float speed = 20.0f;
    float gravity = -9.8f;
    private float turnSpeed = 50.0f;
    private float horizontalInput;

    private bool isGrounded = true;
    public float jumpForce = 5f;

    private Rigidbody rb;


    private void Start()
    {
        playerData = new PlayerData();
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement based on user input (continuous)
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));

        // Apply gravity when not grounded
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * gravity * Time.deltaTime); // Add gravity in FixedUpdate
            isGrounded = true;
        }

        // Jump with impulse force
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            Debug.Log("Player collided with an object tagged with 'Spikes'");
            // Add your collision handling code here
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Win"))
        {
            Debug.Log("You won!");
            speed = 0.0f; gravity = 0.0f; turnSpeed = 0.0f;
            playerData.levels+=1;
            SceneManager.LoadScene("Next_level");
        }
    }
}
