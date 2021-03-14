using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private int NumberOfZombiesToSpawn;
    [SerializeField]
    private GameObject[] ZombiePrefab;
    [SerializeField]
    private SpawnerVolume[] SpawnVolumes;

    private GameObject FollowGameObject;

    // Start is called before the first frame update
    void Start()
    {
        FollowGameObject = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < NumberOfZombiesToSpawn; i++)
        {
            SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        GameObject zombieToSpawn = ZombiePrefab[Random.Range(0, ZombiePrefab.Length)];
        SpawnerVolume spawnVolume = SpawnVolumes[Random.Range(0, SpawnVolumes.Length)];

        if (!FollowGameObject)
        {
            return;
        }

        GameObject zombie = Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);
        zombie.GetComponent<ZombieComponent>().Initialize(FollowGameObject);
    }
}
