using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class PlayerController : MonoBehaviour
{
    public float height;
    public float speed;
    public float tilt;
    public Boundary boundary;

    Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        m_Rigidbody.velocity = movement * speed;

        m_Rigidbody.position = new Vector3(Mathf.Clamp(m_Rigidbody.position.x, boundary.xMin, boundary.xMax), height, 0.0f);

        m_Rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, m_Rigidbody.velocity.x * -tilt);

    }
}