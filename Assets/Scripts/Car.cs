using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float speedGainPerSecond = 0.001f;

    void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
