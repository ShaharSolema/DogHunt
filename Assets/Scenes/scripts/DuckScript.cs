using System.Collections;
using UnityEngine;

public class DuckScript : MonoBehaviour
{
    private float speed;
    private Vector3 movementDirection;
    private int choosingAudio;

    private AudioSource audioSource;

    private GameManagerDuckHunt gm;

    void Start()
    {
        // sets movement direction to random values
        speed = Random.Range(1f, 6f);
        movementDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1f), 0f).normalized;
        GetComponent<SpriteRenderer>().flipX = movementDirection.x < 0 ? true : false;
        var gameObject = GameObject.FindWithTag("GameManager");
        gm = gameObject.GetComponent<GameManagerDuckHunt>();
        choosingAudio = Random.Range(0, gm.GetComponent<GameManagerDuckHunt>().audioClips.Length);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // moves the duck in a direction
        transform.Translate(movementDirection * speed * Time.deltaTime);

    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Bounds")// going out of bounds
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Shot")//getting hit by a bullet
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManagerDuckHunt>().IncreaseScore((int)speed);
            AudioSource.PlayClipAtPoint(gm.GetComponent<GameManagerDuckHunt>().audioClips[choosingAudio], transform.position);
            Destroy(this.gameObject);

        }

    }
}
