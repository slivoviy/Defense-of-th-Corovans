using Scriptable_Objects;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public Enemy enemy;
    [SerializeField] private GameManager m;
    private GameObject bar;
    private float fill; //заполненность бара
    private int _hp;

    public void setM(GameObject a) {
        m = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start() {
        // bar = GameObject.Find("Health Bar");

        _hp = enemy.health;
        // bar.GetComponent<Image>().fillAmount = 1;
    }

    private void OnTriggerEnter2D(Collider2D target) {
        Debug.Log(target.gameObject.tag);
        if (target.gameObject.CompareTag("Bullet")) {
            // bar.SetActive(true);
            Debug.Log(_hp + " 1");
            var w = target.gameObject.GetComponent<Bullet>().weapon;
            _hp -= w.bulletDamage;
            Debug.Log(_hp + " 2");
            //ChangeBarProgress(_hp);
            Destroy(target.gameObject);
        }

        if (_hp < 0) {
            m.Money4Kill = enemy.moneyForKill;
            m.KillerMoney();
            // bar.SetActive(false);
            Destroy(gameObject);
        }
    }

    void ChangeBarProgress(int _hp) {
        Debug.Log("Изменение шкалы");
        if (_hp > 0 && _hp < enemy.health) {
            fill -= 1 - _hp / enemy.health;
            if (fill > 0 && fill <= 1) {
                bar.GetComponent<Image>().fillAmount = fill; //изменение заполненности
                //gameObject.GetComponentInChildren<Image>().fillAmount = fill;
            }
        }
        else {
            bar.SetActive(false);
        }
    }
}