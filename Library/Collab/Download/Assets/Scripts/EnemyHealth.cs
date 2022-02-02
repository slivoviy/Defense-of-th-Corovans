using Scriptable_Objects;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Enemy enemy;
    [SerializeField] private GameManager m;
    private GameObject bar;
    private float fill; //заполненность бара
    private int _hp;

    public void setM(GameObject a)
    {
        Debug.Log("hey");
        m = a.GetComponent<GameManager>();
    }

    void Start()
    {
        bar = GameObject.Find("Health Bar");
        fill = 1;
        _hp = enemy.health;
        bar.GetComponent<Image>().fillAmount = 1;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Bullet"))
        {
            bar.SetActive(true);
            Debug.Log("ѕопал в моба");
            var w = target.gameObject.GetComponent<Bullet>().weapon;
            _hp -= w.bulletDamage;
            ChangeBarProgress(w.bulletDamage);
            Destroy(target.gameObject);
        }

        if (_hp < 0)
        {
            m.Money4Kill = enemy.moneyForKill;
            m.KillerMoney();
            bar.SetActive(false);
            Destroy(gameObject);
        }
    }

    void ChangeBarProgress(int damadge)
    {
        Debug.Log("»зменение шкалы");
        if (fill > 0 && fill <= 1)
        {
            fill -= damadge - enemy.health;
            bar.GetComponent<Image>().fillAmount = fill; //изменение заполненности
        }
        else
        {
            bar.SetActive(false);
        }
    }
}