using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] Rigidbody rb;
    public bool isGrounded;
    public float jumpForce = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Update()

    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        rb.AddForce(direction * force, ForceMode.Force);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Choque contra: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Item"))
        {

            Debug.Log("ITEMMM >>>>>>>>>>>>>>>>");

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Kill"))
        {

            SceneManager.LoadScene(0);

        }
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }
    void OnCollisionExit(Collision other)
    {
        isGrounded = false;

    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
