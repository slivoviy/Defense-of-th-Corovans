using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_spawn_down : MonoBehaviour
{
    public float spawn_rate_sec;
    public int left, right;
    public float spawn_rate_up_per_sec;
    public float offsety;
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
        enemy.transform.position = new Vector3(Random.Range(left, right), transform.position.y + offsety,  0);
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
