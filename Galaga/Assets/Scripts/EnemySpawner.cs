using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    public Transform bulletPool = default;
    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    public float speed = default;
    //private Rigidbody 
    // Start is called before the first frame update
    void Start()
    {

        //Instantiate(bulletPrefab,
        //           transform.position, transform.rotation, bulletPool);
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;


    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;


        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab,
                transform.position, transform.rotation, bulletPool);
            


            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
