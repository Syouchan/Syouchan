using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Spin : MonoBehaviour
{
    public GameObject move;
    float nowtime;
    float start_time;
    public float speed;
    public float time;
    bool turn = false;
    public float m_rotateSpeed = 50;
    public Rigidbody m_rigidbody = null;
    private float m_angle;

    private void Reset()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.isKinematic = true;
    }
    void Start()
    {
        start_time = Time.time;
    }

    void Update()
    {
        nowtime = Time.time;
        if (nowtime - start_time > time && turn == false)
        {
            turn = true;
            start_time = Time.time;

        }
        else if (turn)
        {
            transform.Translate(-speed, 0, 0);
            if (nowtime - start_time > time)
            {
                start_time = Time.time;
                turn = false;
            }
        }
        else if (nowtime - start_time < time && turn == false)
        {
            transform.Translate(speed, 0, 0);
        }
        {
            m_angle += m_rotateSpeed * Time.deltaTime;
            var rotation = Quaternion.Euler(0, m_angle, 0);
            m_rigidbody.MoveRotation(rotation);
        }
    }
}
