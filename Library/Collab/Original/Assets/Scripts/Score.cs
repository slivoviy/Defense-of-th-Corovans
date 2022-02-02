using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score, add_per_sec;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void addscore() {
        //this.text("score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator enemywave()
    {
        while (true)  // заменить на GameRunning 
        {
            yield return new WaitForSeconds(1);
            addscore();
        }
    }
}
