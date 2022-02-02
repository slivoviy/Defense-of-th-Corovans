using UnityEngine;

public class CorovanHealth : MonoBehaviour {
    public GameManager gameManager;

    

    private void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.CompareTag("Sword")) {
            gameManager.SubtractHealth(target.gameObject.GetComponentInParent<EnemyHealth>().enemy.damage);
        }
    }
}