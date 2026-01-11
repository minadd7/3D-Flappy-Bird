using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pipe;

    private float xPos = 29;
    private float yPos;
    private float zPos = -101.3f;
    private float repeatRate = 1.5f;

    public void StartSpawning()
    {
        // InvokeRepeating("SpawnPipe", startDelay, repeatRate);
        StartCoroutine(SpawnPipe());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // void SpawnPipe()
    // {
    //     yPos = Random.Range(66.98f, 78.05f);
    //     Vector3 spawnPos = new Vector3(xPos, yPos, zPos);

    //     Instantiate(pipe, spawnPos, pipe.transform.rotation);
    // }

    IEnumerator SpawnPipe()
    {
        while (GameManager.isGameActive)
        {
            yield return new WaitForSeconds(repeatRate);
            yPos = Random.Range(66.98f, 78.05f);
            Vector3 spawnPos = new Vector3(xPos, yPos, zPos);

            Instantiate(pipe, spawnPos, pipe.transform.rotation);
        }
    }
}
