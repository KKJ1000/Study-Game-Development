using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //게임오버 시 활성화 되는 텍스트 게임 오브젝트
    public Text timeText; //생존 시간 텍스트
    public Text recordText; //최고 기록 텍스트

    private float surviveTime; //생존 시간
    private bool isGameover; //게임 오버 상태

    void Start()
    {
        // 생존 시간과 게임오버 상태 초기화
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 텍스트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    //현재 게임 상태를 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        //현재 겡미 상태를 게임 오버상태로 변환
        isGameover = true;
        //게임오버 텍스트 활성화
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
