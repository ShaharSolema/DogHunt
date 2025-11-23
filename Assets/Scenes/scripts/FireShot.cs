
using UnityEngine;

public class FireShot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Vector3 direction;
    private float speed = 10f;



    void Start()
    {
        direction = Vector3.up;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bounds" || collision.gameObject.tag == "Duck")
        {
            Destroy(this.gameObject);
        }
    }
}
