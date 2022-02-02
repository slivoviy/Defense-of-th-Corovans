using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.PackageManager.UI;
using Random = UnityEngine.Random;

//using Random = System.Random;



public class Mob_spawn : MonoBehaviour
{
    public float spawn_rate_sec;
    public int up, down;
    public float spawn_rate_up_per_sec;
    public float offsetx;
    public List<GameObject> enemies;
    //private Random rnd = new Random();
    float k, b;
    int kint, bint;
    
    void Start()
    {
        StartCoroutine(enemywave());
    }
    private void spawn()
    {
        int a = Random.Range(0,enemies.Count);
        GameObject enemy = Instantiate(enemies[a].gameObject);
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        enemy.transform.position = new Vector3(transform.position.x + offsetx, UnityEngine.Random.Range(down, up), 0);
        // при счете кратным n можно ставить дом
    }

    IEnumerator enemywave()
    {
        while (true)  // заменить на GameRunning 
        {
            yield return new WaitForSeconds(spawn_rate_sec - spawn_rate_up_per_sec);
            spawn();
        }
    }
}
