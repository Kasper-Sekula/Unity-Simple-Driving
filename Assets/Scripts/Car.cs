using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float speedGainPerSecond = 0.001f;
    [SerializeField] float turnSpeed = 200f;

    private int steerValue;

    void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;

        transform.Rotate(0, steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Steer(int value)
    {
        steerValue = value;
    }
}
