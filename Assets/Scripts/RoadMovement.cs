using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    public GameObject RoadPiece;
    float RoadLength = 30f; //����� ������
    const float RoadSpeed = 10f; //�������� �������� ������
    Vector3 newRoadPos;

    // Update is called once per frame
    void Update()
    {
        newRoadPos = RoadPiece.transform.position;
        newRoadPos.y -= RoadSpeed * Time.deltaTime; //������ ����
        RoadPiece.transform.position = newRoadPos; //��������� ������� �������� �����
    }
}