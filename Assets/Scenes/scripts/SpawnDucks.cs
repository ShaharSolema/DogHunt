using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDucks : MonoBehaviour
{
    public GameObject duck;
    public Transform spawnPosition;

    private Coroutine spawnRoutine;
    [HideInInspector] public bool gameIsRunning = false;

    void Start()
    {

    }




    [HideInInspector]
    public void StartGame()
    {


        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);
        spawnRoutine = StartCoroutine(SpawnDucksCoroutine());
    }

    private IEnumerator SpawnDucksCoroutine()
    {
        while (gameIsRunning)//spawn duck every 0.4f
        {
            yield return new WaitForSeconds(0.4f);

            Vector3 newSpawn = new Vector3(Random.Range(-5f, 5f), spawnPosition.position.y, 0f);
            Instantiate(duck, newSpawn, Quaternion.identity);

        }
    }

    [HideInInspector]
    public void EndGame()
    {

        gameIsRunning = false;
        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);

        foreach (var existingDuck in GameObject.FindGameObjectsWithTag("Duck"))
        {
            Destroy(existingDuck);
        }


    }
}
