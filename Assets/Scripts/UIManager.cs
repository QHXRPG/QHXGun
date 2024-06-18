using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // ����ģʽ���������������
    public static UIManager instance;

    // ������ʾHP��ͼ������
    public Image[] hpImages;

    // ���ڱ�ʾ��HP��ͼ��
    public Sprite blockHpImage;

    // ���ڱ�ʾ��HP��ͼ��
    public Sprite redHpImage;

    // ��ǰ�ķ���
    public int score;

    // ��ʾ��ǰ������UI�ı�
    public Text textCurrent;

    // �ڽű�ʵ����ʱ���ã���ʼ������
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �ڽű�����ʱ���ã���ʼ������
    private void Start()
    {
        score = 0;
        UpdateHp(Globalx.PlayHpMax);
    }

    // ����HP��ʾ
    public void UpdateHp(int _hp)
    {
        for (int i = 0; i < Globalx.PlayHpMax; i++)
        {
            if (i < _hp)
            {
                // �����ǰ����С��HPֵ����ͼ������Ϊ��ɫ������
                hpImages[i].sprite = redHpImage;
                hpImages[i].gameObject.SetActive(true);
            }
            else
            {
                // �����ǰ�������ڵ���HPֵ����ͼ������Ϊ��
                hpImages[i].sprite = blockHpImage;
            }
        }
    }

    // ���·�����ʾ
    public void UpdateScore()
    {
        textCurrent.text = "��ǰ������" + score;
    }
}
