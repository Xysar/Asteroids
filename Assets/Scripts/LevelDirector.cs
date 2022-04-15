using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDirector : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    GameObject player;
    float spawnDistance = 100f;
    float enemyRate = 9;
    float nextEnemy = 5;
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject newplayer = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newplayer.name = "SpaceShip";
            player = newplayer;
        }
        nextEnemy -= Time.deltaTime;
        if(nextEnemy<= 0)
        {
            nextEnemy = enemyRate;

            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            offset = offset.normalized * spawnDistance;
            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
        }
    }
}


