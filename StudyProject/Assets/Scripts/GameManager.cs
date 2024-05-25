using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //���ӿ��� �� Ȱ��ȭ �Ǵ� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText; //���� �ð� �ؽ�Ʈ
    public Text recordText; //�ְ� ��� �ؽ�Ʈ

    private float surviveTime; //���� �ð�
    private bool isGameover; //���� ���� ����

    void Start()
    {
        // ���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        surviveTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            //������ ���� �ð��� �ؽ�Ʈ�� �̿��� ǥ��
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

    //���� ���� ���¸� ���ӿ��� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        //���� �۹� ���¸� ���� �������·� ��ȯ
        isGameover = true;
        //���ӿ��� �ؽ�Ʈ Ȱ��ȭ
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
