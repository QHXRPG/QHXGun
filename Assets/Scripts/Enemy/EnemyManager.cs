using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{ 
    // �����������ɵļ��ʱ��
    public float timeOne = 2;
    // һ��������ɵļ��ʱ��
    public float timeGroup = 40;
    // ��ʾʣ��ʱ���UI�ı�
    public Text timeRefresh;

    private void Start()
    {
        // ��ʼʱ�����������ɵ��˵�Э�̣��ӳ�3��
        StartCoroutine(CreateEnemy(3f));
    }

    private void Update()
    {
        // ���µ����������ɵĵ���ʱ
        timeOne -= Time.deltaTime;
        if (timeOne <= 0)
        {
            // ������ʱ�������ӵ��˳��л�ȡһ������
            EnemyPool.instance.Get();
            // ���õ���ʱʱ��
            timeOne = 2;
        }

        // ����һ��������ɵĵ���ʱ
        timeGroup -= Time.deltaTime;
        if (timeGroup <= 0)
        {
            // ������ʱ���������õ���ʱʱ�䲢�������ɵ��˵�Э��
            timeGroup = 40;
            StartCoroutine(CreateEnemy(0f));
        }
        else
        {
            // ����UI�ı�����ʾ��һ���������ɵ�ʣ��ʱ��
            timeRefresh.text = "��һ������ʣ�ࣺ" + (int)timeGroup + "��";
        }
    }

    // Э����������һ�����
    private IEnumerator CreateEnemy(float _time)
    {
        // �ȴ�ָ����ʱ��
        yield return new WaitForSeconds(_time);

        // �������˳��е����е��ˣ����ӳ��л�ȡ����
        for (int i = 0; i < EnemyPool.instance.objectPool.Count; i++)
        {
            EnemyPool.instance.Get();
        }
    }
}
