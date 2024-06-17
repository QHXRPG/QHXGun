using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // ����������ײ����봥����ʱ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �����ײ���Ƿ�����ң���������Ƿ��ڱ�����״̬
        if (collision.gameObject.CompareTag("Player") && !collision.gameObject.GetComponent<ITakenDamage>().isAttack)
        {
            // ��ȡ��ҵ�ITakenDamage�ӿ�
            ITakenDamage player = collision.gameObject.GetComponent<ITakenDamage>();

            // ���������˺����˺�ֵΪ1
            player.TakenDamage(1);
        }
    }
}
