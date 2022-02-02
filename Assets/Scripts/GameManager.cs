using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float score = 0;
    public GameObject scoretext; 
    public GameObject moneytext;
    public int add_per_sec;
    private float t;
    
    public int Money4Kill;
    public int StolenMoney;
    public int TotalMoney = 0;
    
    public int SpawnLimit;
    public float spawnwait;

    public int corovanHealth;
    public TextMeshProUGUI healthText;
    public List<GameObject> toDestroy;

    [SerializeField] private GameObject panel;

    public void Start()
    {
        moneytext.GetComponent<TMPro.TextMeshProUGUI>().text = TotalMoney.ToString();
        t = 1f / add_per_sec;
        StartCoroutine(wave());
    }

    void addscore()
    {
        score++;
        scoretext.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score.ToString(); // Возможна иконка?
        
    }

    IEnumerator wave()
    {
        while (true) // заменить на GameRunning 
        {
            yield return new WaitForSeconds(t);
            addscore();
        }
    }
    
    public void KillerMoney()   // Начисление при убийсте
    {
        TotalMoney += Money4Kill;
        int rnd = Random.Range(0, 2);
        SpawnLimit--;
        moneytext.GetComponent<TMPro.TextMeshProUGUI>().text = TotalMoney.ToString();
    }

    public void purchase(int sum)
    {
        TotalMoney -= sum;
        moneytext.GetComponent<TMPro.TextMeshProUGUI>().text = TotalMoney.ToString();
    }

    public void TheyStoleIT()   // При стук стук по повозке
    {
        TotalMoney -= StolenMoney;
        moneytext.GetComponent<TMPro.TextMeshProUGUI>().text = TotalMoney.ToString();
    }

    public void SubtractHealth(int health) {
        corovanHealth -= health;
        healthText.text = corovanHealth.ToString();

        if (corovanHealth <= 0) {
            GameOver();
        }
    }


    public void GameOver() {
        foreach (var o in toDestroy) {
            Destroy(o);
        }

        Time.timeScale = 0f;
        panel.SetActive(true);

        Time.timeScale = 1f;
        Reload();
    }

    public IEnumerator Reload() {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("SampleScene");
    }
}
