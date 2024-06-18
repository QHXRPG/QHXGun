using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject loseObj; // ʧ�ܶ���
    public GameObject player; // ��Ҷ���
    public GameObject enemyManager; // ���˹������

    public int targetScore; // Ŀ�����

    public Text targetText; // ��ʾĿ��������ı�

    private void Awake()
    {
        targetScore = 9999;
    }

    private void Start()
    {
        // ����Ϸ��ʼʱ����Ŀ��������ı�
        targetText.text = "Ŀ�������" + targetScore.ToString();
        // ��ʼ��ʱ����ʤ����ʧ�ܶ���
        loseObj.SetActive(false);
    }

    private void Update()
    {
        int score = UIManager.instance.score; // ��ȡ��ǰ�÷�
        // ��������������������Ϸʧ���߼�
        if (!PlayerHealth.isAlive)
        {
            Debug.Log("��Ϸʧ�ܣ�");
            loseObj.SetActive(true); // ��ʾʧ�ܶ���
            player.SetActive(false); // ������Ҷ���
            enemyManager.SetActive(false); // ֹͣ���˹���
        }
    }

    // ������ǰ��Ϸ����
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
