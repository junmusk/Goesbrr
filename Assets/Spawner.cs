using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject[] enemyPrefabs;

    private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(Spawners());
    }

    private IEnumerator Spawners() {
        int minutes = PlayerPrefs.GetInt("minutes");
        WaitForSeconds wait = new WaitForSeconds(spawnRate + minutes);

        while (canSpawn) {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length);


            Instantiate(enemyPrefabs[rand], transform.position, Quaternion.identity);
            

        }
    }
}
