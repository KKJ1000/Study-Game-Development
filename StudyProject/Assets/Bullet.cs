using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //ź�� �ӷ�
    Rigidbody bulletRigid;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigid = GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * speed;

        //3�� �� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            
            if(playerController != null)
            {
                //��� �Լ� ����
                playerController.Die();
            }
        }
    }
}
