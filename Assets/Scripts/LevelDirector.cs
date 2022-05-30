using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDirector : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject playerPrefab;
    GameObject player;
    float spawnDistance = 100f;
    float enemyRate = 9;
    float nextEnemy = 5;
    Camera cam;
    bool visible;
     void Start()
    {
        GameObject newplayer = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newplayer.name = "SpaceShip";
        player = newplayer;
        cam = Camera.main;
        visible = true;
    }


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
            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(enemy, transform.position + offset, Quaternion.identity);
        }

        Vector2 newPosition = player.transform.position;

        if (!visible)
        {
            if(newPosition.x > -430 && newPosition.x < 430 && newPosition.y < 300 && newPosition.y > -300)
            {
                visible = true;
            }
            return;
        }

        if (newPosition.x < -430 || newPosition.x > 430)
        {
            newPosition.x = -newPosition.x;
            visible = false;
        }
        if (newPosition.y < -300 || newPosition.y > 300)
        {
            newPosition.y = -newPosition.y;
            visible = false;
        }
        player.transform.position = newPosition;
        
    }
}


