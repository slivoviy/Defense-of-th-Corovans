using System;
using UnityEngine;

public class RotateCowboy : MonoBehaviour {
    private float _initialRotationZ;

    private void Start() {
        _initialRotationZ = transform.localEulerAngles.z;
    }


    void FixedUpdate() {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 difference = worldPoint - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90 + _initialRotationZ);
    }
}