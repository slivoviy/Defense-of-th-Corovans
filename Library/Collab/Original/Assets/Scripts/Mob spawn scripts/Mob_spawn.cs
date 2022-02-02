using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;
using UnityEditor.PackageManager.UI;
using Random = UnityEngine.Random;

//using Random = System.Random;



public class Mob_spawn : MonoBehaviour
{
    public Score sc;
    public float spawn_rate_sec;
    public float mobSpawnSpeedFromScore;
    public int up, down;
    private float spawnwait;
    public float offsetx;
    public List<GameObject> enemies;
    
    [SerializeField] private List<Transform> destinations;
    private List<Transform> _listOfDestinations;

    [SerializeField] private bool isLeft;
    
    void Start()
    {
        _listOfDestinations = destinations;
        
        float sco = float.Parse(sc.score.ToString());   
        spawnwait = spawn_rate_sec - (sco / mobSpawnSpeedFromScore) / 10f;
        spawn();
        StartCoroutine(enemywave());
        
    }
    private void spawn()
    {
        int a = Random.Range(0,enemies.Count);
        GameObject enemy = Instantiate(enemies[a].gameObject);
        enemy.transform.position = new Vector3(transform.position.x + offsetx, Random.Range(down, up), 0);
        enemy.gameObject.GetComponent<EnemyHealth>().setM(GameObject.Find("/Lms/Money"));
        
        if (isLeft) {
            var localScale = enemy.transform.localScale;
            localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
            enemy.transform.localScale = localScale;
        }
        
        if (_listOfDestinations.Count == 0) _listOfDestinations = destinations;
        a = Random.Range(0, _listOfDestinations.Count);
        enemy.gameObject.GetComponent<AIDestinationSetter>().target = _listOfDestinations[a];
        _listOfDestinations.RemoveAt(a);

    }

    IEnumerator enemywave()
    {
        while (true)  // заменить на GameRunning 
        {
            yield return new WaitForSeconds(spawnwait);
            spawn();
        }
    }
}
