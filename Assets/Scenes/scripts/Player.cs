using System.Xml.Serialization;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D rb;
    [HideInInspector] public bool isStarted = false;
    [HideInInspector] public bool isFlipped = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-0.3f, -3.90f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            float moveInput = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
            if (rb.linearVelocity.x < 0)
            {
                isFlipped = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                isFlipped = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            float clampedX = Mathf.Clamp(transform.position.x, -7.5f, 7.5f); // change -8/8 to fit your camera
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        }
        else
        {
            GetComponent<PlayerShooting>().EndGame();
        }
    }

    [HideInInspector]
    public void StartGame()
    {
        transform.position = new Vector3(-0.3f, -3.90f, 0);
    }

}
