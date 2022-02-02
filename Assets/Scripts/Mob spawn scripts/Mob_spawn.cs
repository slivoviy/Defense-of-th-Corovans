using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;

//using Random = System.Random;



public class Mob_spawn : MonoBehaviour
{
    private float spawnwait;
    public float spawn_rate_sec;
    public float mobSpawnSpeedFromScore;
    public GameManager gm;
    public int up, down;
    public float offsetx;
    public List<GameObject> enemies;
    
    
    [SerializeField] private List<Transform> destinations;
    private List<Transform> _listOfDestinations;

    [SerializeField] private bool isLeft;
    
    void Start()
    {
        _listOfDestinations = new List<Transform>(destinations);
        StartCoroutine(enemywave());
    }
    private void spawnlr()
    {
        gm.SpawnLimit++;
        int a = Random.Range(0,enemies.Count);
        GameObject enemy = Instantiate(enemies[a].gameObject);
        enemy.transform.position = new Vector3(transform.position.x + offsetx, Random.Range(down, up), 0);
        enemy.gameObject.GetComponent<EnemyHealth>().setM();

        if (_listOfDestinations.Count == 0) {
            _listOfDestinations = new List<Transform>(destinations);
        }
        
        a = Random.Range(0, _listOfDestinations.Count);
        enemy.gameObject.GetComponent<AIDestinationSetter>().target = _listOfDestinations[a];
        _listOfDestinations.RemoveAt(a);
        
        if (isLeft) {
            var localScale = enemy.transform.localScale;
            localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
            enemy.transform.localScale = localScale;
        }

    }

    IEnumerator enemywave()
    {
        
        while (true)  
        {
            
            yield return new WaitForSeconds(Random.Range(2, 5));
            if (gm.SpawnLimit < 17)
            {
                spawnlr();
            }


        }
    }
}

