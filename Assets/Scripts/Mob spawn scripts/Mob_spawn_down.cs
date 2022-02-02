using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using TMPro;
using UnityEngine;

public class Mob_spawn_down : MonoBehaviour
{

    public GameManager gm;
    public int left, right;
    public float offsety;
    public List<GameObject> enemies;
    private float spawnwait;
    public float spawn_rate_sec;
    public float mobSpawnSpeedFromScore;

    public List<Transform> destinations;
    private List<Transform> _listOfDestinations;

    
    void Start() {
        _listOfDestinations = new List<Transform>(destinations);
        StartCoroutine(Enmywave());
    }
    private void Spawndown()
    {
        Debug.Log("spawning");
        gm.SpawnLimit++;
        int a = Random.Range(0,enemies.Count);
        GameObject enemy = Instantiate(enemies[a].gameObject);
        enemy.transform.position = new Vector3(Random.Range(left, right), transform.position.y + offsety,  0);
        enemy.gameObject.GetComponent<EnemyHealth>().setM();
        
        if (_listOfDestinations.Count == 0) {
            _listOfDestinations = new List<Transform>(destinations);
        }
        
        a = Random.Range(0, _listOfDestinations.Count);
        enemy.gameObject.GetComponent<AIDestinationSetter>().target = _listOfDestinations[a];
        _listOfDestinations.RemoveAt(a);
    }

    IEnumerator Enmywave()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(3, 6));
            if (gm.SpawnLimit < 17)
            {
                Spawndown();
            } 
            
        }
    }
}
