using UnityEngine;

public class RemoveEverything : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Bullet")) Destroy(target.gameObject);
    }
}
