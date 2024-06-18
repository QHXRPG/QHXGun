using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ITakenDamage ��һ���ӿڣ������������п����ܵ��˺��Ķ�������Һ͵��ˣ�Ӧ��ʵ�ֵ���Ϊ��
/// ������˵������һ�� isAttack ���ԣ����ڱ�ʾ�����Ƿ����ڱ�������
/// �Լ�һ�� TakenDamage ���������ڴ�������ܵ����˺���
/// </summary>
public interface ITakenDamage
{
    // ����һ��bool���͵����ԣ����ڱ�ʾ�Ƿ����ڱ�����
    bool isAttack { get; set; }

    // ����һ�����������ڴ����ܵ����˺�������Ϊ�˺�ֵ
    void TakenDamage(int _amount);
}
