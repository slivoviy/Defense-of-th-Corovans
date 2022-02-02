using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    public GameObject RoadPiece;
    float RoadLength = 30f; //длина дороги
    const float RoadSpeed = 10f; //скорость движения дороги
    Vector3 newRoadPos;

    // Update is called once per frame
    void Update()
    {
        newRoadPos = RoadPiece.transform.position;
        newRoadPos.y -= RoadSpeed * Time.deltaTime; //движет вниз
        RoadPiece.transform.position = newRoadPos; //обновляет позицию текущего куска
    }
}