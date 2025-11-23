using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletpos;
    private float timer = 1.5f;

    [SerializeField] private SpriteRenderer SpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 1.5 && Input.GetKeyDown(KeyCode.Space))
        {
            shoot();

        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletpos.position, Quaternion.identity);
    }


    [HideInInspector]
    public void EndGame()
    {
        foreach (var shot in GameObject.FindGameObjectsWithTag("Shot"))
        {
            if (shot != null)
            {
                Destroy(shot);
            }
        }
    }
}