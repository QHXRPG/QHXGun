using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITakenDamage
{
    [HideInInspector] public bool isAttacked; // ����Ƿ����ڱ�����

    public bool isAttack { get { return isAttacked; } set { isAttacked = value; } } // isAttack���ԣ����ڻ�ȡ������isAttacked��ֵ

    private Animator anim; // ��ҵĶ������
    static public bool isAlive;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isAlive = true;
    }

    // ������ܵ��˺�ʱ����
    public void TakenDamage(int _amount)
    {
        // ������û�б�����
        if (!isAttack) 
        {
            anim.SetTrigger("isHurt"); // �������˶���
            isAttack = true; // �������Ϊ������״̬
            StartCoroutine(InvincibleCo()); // �����޵�ʱ��Э��
            BoxCollider2D collider = GetComponent<BoxCollider2D>(); // ��ȡ��ҵ���ײ��
            collider.isTrigger = true; // ������ײ��Ϊ������
            Globalx.PlayHp--; // ����ֵ��1
            UIManager.instance.UpdateHp(Globalx.PlayHp); // ����UI��ʾ������ֵ

            // �������ֵΪ0������
            if (Globalx.PlayHp <= 0) 
            {
                isAlive = false; // ��Ϸʧ��
            }
        }
    }

    // �޵�ʱ��Э��
    private IEnumerator InvincibleCo()
    {
        yield return new WaitForSeconds(2.0f); // �ȴ�2��
        BoxCollider2D collider = GetComponent<BoxCollider2D>(); // ��ȡ��ҵ���ײ��
        collider.isTrigger = false; // ������ײ��Ϊ�Ǵ�����
        isAttack = false; // �������Ϊ�Ǳ�����״̬
    }

    // ����Ҵ���������ײ��ʱ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �����������Ѫ��
        if (collision.gameObject.CompareTag("Blood")) 
        {
            if (Globalx.PlayHp < Globalx.PlayHpMax) // �������ֵС��PlayHpMax
            {
                Globalx.PlayHp++; // ����ֵ��1
                UIManager.instance.UpdateHp(Globalx.PlayHp); // ����UI��ʾ������ֵ
                Destroy(collision.gameObject); // ����ѪҺ
            }
        }
    }
}
