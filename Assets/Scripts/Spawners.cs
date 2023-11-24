using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] Transform[] spawners;
    [SerializeField] GameObject[] fruits;

    [SerializeField] float minTime = 0.25f, maxTime = 2f;

    private void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        float randomTime = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomTime);

        while (true)
        {
            GameObject randomFruit = fruits[Random.Range(0, fruits.Length)];

            int randomIndex = Random.Range(0, spawners.Length);
            Transform randomPos = spawners[randomIndex];

            GameObject spawn = Instantiate(randomFruit, randomPos.transform.position, randomPos.transform.rotation);
            Destroy(spawn, 3f);

            yield return new WaitForSeconds(1.5f);
        }
    }


  
}
