using UnityEngine;

public class RespawRoad : MonoBehaviour
{
    float RoadLength = 31.32f; //длина дороги
    Vector3 resp_pos;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Road")
        {
            resp_pos = target.transform.position; //обращаемся к позиции объекта
            resp_pos.y = RoadLength; //перемещение позиции
            target.transform.position = resp_pos;
        }
    }
}
