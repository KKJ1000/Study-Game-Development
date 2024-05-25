using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //생성할 탄알 프리팹
    public float spawnRateMin = 0.5f; //탄알 최소 생성 주기
    public float spawnRateMax = 3f; //탄알 최대 생성 주기

    Transform target; //발사 할 대상
    float spawnRate; //생성 주기
    float timeAfterSpawn; //최근 생성 시점에서 지난 시간
    
    void Start()
    {
        //최근 생성 이후 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //탄알 생성 간격을 Min,Max 사이에서 랜덤 지정
        target = FindObjectOfType<PlayerController>().transform; //PlayerController 스크립트를 가진 오브젝트를 찾아 타겟으로 설정
        
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
