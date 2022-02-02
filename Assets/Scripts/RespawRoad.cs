using UnityEngine;

public class RespawRoad : MonoBehaviour
{
    float RoadLength = 31.32f; //����� ������
    Vector3 resp_pos;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Road")
        {
            resp_pos = target.transform.position; //���������� � ������� �������
            resp_pos.y = RoadLength; //����������� �������
            target.transform.position = resp_pos;
        }
    }
}
