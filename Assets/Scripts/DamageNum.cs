using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// DamageNum �����Ҫ������������ʱ��������ʱ�䣬ʹ�˺���������Ļ�ϻ�������������ʾ������˺���ֵ��
/// </summary>
public class DamageNum : MonoBehaviour
{
    public Text damageText; // ��ʾ�˺���ֵ���ı����
    public float lifeTime; // �˺����ֵ�����ʱ��
    public float moveSpeed; // �˺����ֵ��ƶ��ٶ�

    // �ڽű�����ʱ����
    private void Start()
    {
        // ��ָ��������ʱ������ٸö���
        Destroy(gameObject, lifeTime);
    }

    // ÿ֡����ʱ����
    private void Update()
    {
        // ʹ�˺�������Y�����ƶ�
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }

    // ��ʾ�˺���ֵ
    public void ShowDamage(int _amount)
    {
        // �����ı������ʾ������Ϊ������˺���ֵ
        damageText.text = _amount.ToString();
    }
}
