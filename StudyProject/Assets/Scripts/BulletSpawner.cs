using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //������ ź�� ������
    public float spawnRateMin = 0.5f; //ź�� �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; //ź�� �ִ� ���� �ֱ�

    Transform target; //�߻� �� ���
    float spawnRate; //���� �ֱ�
    float timeAfterSpawn; //�ֱ� ���� �������� ���� �ð�
    
    void Start()
    {
        //�ֱ� ���� ���� ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //ź�� ���� ������ Min,Max ���̿��� ���� ����
        target = FindObjectOfType<PlayerController>().transform; //PlayerController ��ũ��Ʈ�� ���� ������Ʈ�� ã�� Ÿ������ ����
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;


            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
