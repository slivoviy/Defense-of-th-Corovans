using UnityEngine;

public class GunSightPosition : MonoBehaviour
{
    private void FixedUpdate() {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(worldPoint.x, worldPoint.y);
    }
}
