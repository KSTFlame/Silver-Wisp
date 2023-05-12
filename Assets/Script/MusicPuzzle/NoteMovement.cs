using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{

    private Vector3 m_movement, m_startingPosition;
    public float m_Speed;
    public GameObject m_DeathPoint;
    public float m_Frequency;
    public float m_Magnitude;

    // Start is called before the first frame update
    void Start()
    {
        m_movement = new Vector3(-1, 0, 0);
        m_startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(m_movement * m_Speed * Time.deltaTime);
        m_startingPosition -= transform.right * Time.deltaTime * m_Speed;
        transform.position = m_startingPosition + transform.up * Mathf.Sin(Time.time * m_Frequency) * m_Magnitude;
        if (transform.position.x <= m_DeathPoint.transform.position.x)
        {
            Debug.Log("Ciao");
            Destroy(gameObject);

        }
    }
}
