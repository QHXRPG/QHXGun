using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITakenDamage
{
    [SerializeField] private int maxHp; // ��ҵ��������ֵ
    public int hp; // ��ҵĵ�ǰ����ֵ

    [HideInInspector] public bool isAttacked; // ����Ƿ����ڱ�����
    public bool isAttack { get { return isAttacked; } set { isAttacked = value; } } // isAttack���ԣ����ڻ�ȡ������isAttacked��ֵ

    private Animator anim; // ��ҵĶ������
    static public bool isWin; // ��Ϸ�Ƿ�ʤ��

    private void Start()
    {
        anim = GetComponent<Animator>();
        hp = maxHp; // ��ʼ����ֵΪ�������ֵ
        isWin = true; // ��ʼ״̬Ϊʤ��
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
            hp--; // ����ֵ��1
            UIManager.instance.UpdateHp(hp); // ����UI��ʾ������ֵ

            // �������ֵΪ0������
            if (hp <= 0) 
            {
                isWin = false; // ��Ϸʧ��
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
            if (hp < 3) // �������ֵС��3
            {
                hp++; // ����ֵ��1
                UIManager.instance.UpdateHp(hp); // ����UI��ʾ������ֵ
                Destroy(collision.gameObject); // ����ѪҺ
            }
        }
    }
}
