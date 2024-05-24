using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed = 8f; //�̵� �ӷ�

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float xSpeed = x * speed;
        float zSpeed = z * speed; 

        Vector3 velocity = new Vector3(xSpeed, 0f, zSpeed);
        rigid.velocity = velocity;
    }

    public void Die() //��� �� ȣ��
    {
        gameObject.SetActive(false); //���� ������Ʈ ��Ȱ��ȭ
    }
}
