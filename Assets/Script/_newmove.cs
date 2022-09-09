using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class _newmove : MonoBehaviour
{

    public float m_MovementSpeed = 1.0f;

    public Transform m_CameraTransform;

    public CharacterController m_CharacterController;

    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 forward =(transform.position - m_CameraTransform.position).normalized;
        forward.y = 0f;
        Vector3 right = Vector3.Cross(Vector3.up,forward).normalized;

        float moveAxisX = m_MovementSpeed* Input.GetAxis("Horizontal");
        float moveAxisY = m_MovementSpeed* Input.GetAxis("Vertical");
        Vector3 movement = forward * moveAxisY + right * moveAxisX;

        m_CharacterController.Move(movement);
    } 

}
