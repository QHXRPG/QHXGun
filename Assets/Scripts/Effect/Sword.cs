using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sword �����Ҫ�������ڽ�����ʱ��ʼ������ת�Ƕȣ�
/// ����ײ������ʱ�Ե�������˺�����ʾ�˺���ֵ��
/// ͬʱ���ɱ�ըЧ������΢���˵���
/// </summary>
public class Sword : MonoBehaviour
{
    [SerializeField] private int minAttack, maxAttack; // ��С����󹥻���
    public int attackDamage; // ��ǰ������

    public GameObject damageTextPrefab; // �˺��ı�Ԥ����

    private PlayerAttack playerAttack; // ��ҹ������
    public GameObject boomPrefab; // ��ըЧ��Ԥ����

    // ����������ʱ����
    private void OnEnable()
    {
        // ��ȡ�������PlayerAttack���
        playerAttack = GetComponentInParent<PlayerAttack>();
        // ���ý�����ת�Ƕ�Ϊ��ҹ�������ת�Ƕ�
        transform.rotation = Quaternion.Euler(0, 0, playerAttack.rotZ);
    }

    // ��������ʱ����
    public void EndAttack()
    {
        gameObject.SetActive(false); // ������������Ϊ������״̬
        playerAttack.isSwordAttack = true; // ������ҵĽ�����״̬
    }

    // ����������ײʱ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �����ײ�����ǵ���
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // ������ɹ�����
            attackDamage = Random.Range(minAttack, maxAttack);

            // ��ȡ���˵�ITakenDamage�ӿ�
            ITakenDamage enemy = collision.GetComponent<ITakenDamage>();

            // �Ե�������˺�
            enemy.TakenDamage(attackDamage);

            // ��ʾ�˺���ֵ
            DamageNum damageNum = Instantiate(damageTextPrefab, collision.gameObject.transform.position, Quaternion.identity).GetComponent<DamageNum>();
            damageNum.ShowDamage(attackDamage);

            // ������˱����˵ķ���
            Vector2 difference = collision.transform.position - transform.position;
            difference.Normalize();

            // ������λ����΢�ƶ���ģ�����Ч��
            collision.transform.position = new Vector2(collision.transform.position.x + difference.x / 2,
                                                        collision.transform.position.y + difference.y / 2);

            // �ڵ���λ�����ɱ�ըЧ��
            Instantiate(boomPrefab, collision.gameObject.transform.position, Quaternion.identity);
        }
    }
}

