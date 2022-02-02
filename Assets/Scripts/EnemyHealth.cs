using Scriptable_Objects;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public Enemy enemy;
    [SerializeField] private GameManager m;
    public GameObject bar;
    private float fill; //заполненность бара
    private int _hp;

    public void setM() {
        m = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start() {
        _hp = enemy.health;
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.CompareTag("Bullet")) {
            bar.SetActive(true);
            var w = target.gameObject.GetComponent<Bullet>().weapon;
            _hp -= w.bulletDamage;
            ChangeBarProgress(_hp);
            Destroy(target.gameObject);
        }

        if (_hp < 0) {
            m.Money4Kill = enemy.moneyForKill;
            m.KillerMoney();
            Destroy(gameObject);
        }
    }

    void ChangeBarProgress(int hp) {
        fill =  (float) hp / enemy.health;
        if (fill > 0 && fill <= 1) {
            bar.GetComponentInChildren<Image>().fillAmount = fill; //изменение заполненности
            //gameObject.GetComponentInChildren<Image>().fillAmount = fill;
        }
    }
}