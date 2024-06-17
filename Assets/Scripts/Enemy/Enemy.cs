using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
public class Enemy : MonoBehaviour, ITakenDamage
{
    private Rigidbody2D rb; // ���˵ĸ������
    [SerializeField] private float moveSpeed; // ���˵��ƶ��ٶ�
    private Transform target; // Ŀ�꣨��ң���Transform���
    [SerializeField] private int maxHp; // ���˵��������ֵ
    public int hp; // ���˵ĵ�ǰ����ֵ

    [HideInInspector] public bool isAttacked; // �����Ƿ����ڱ�����
    public bool isAttack { get { return isAttacked; } set { isAttacked = value; } } // isAttack���ԣ����ڻ�ȡ������isAttacked��ֵ

    public GameObject bloodPrefab; // ѪҺԤ����

    // ����������ʱ����
    private void OnEnable()
    {
        hp = maxHp; // ���õ��˵�����ֵ
        isAttack = false; // ���õ��˵Ĺ���״̬

        // ������ɵ��˵�λ��
        float rangeX = Random.Range(-6.3f, 8.7f);
        float rangeY = Random.Range(-3.2f, 2.6f);
        transform.position = new Vector3(rangeX, rangeY);
    }

    // �ڽű�����ʱ����
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ��ȡ���˵ĸ������
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // ��ȡĿ�꣨��ң���Transform���
        hp = maxHp; // ��ʼ�����˵�����ֵ
    }

    // ��ÿ֡����ʱ����
    private void Update()
    {
        FollowPlayer(); // ���˸������
        EnemyOverturn(); // ���˸������λ�÷�ת
    }

    // ���˸������
    public void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    // ���˸������λ�÷�ת
    public void EnemyOverturn()
    {
        if (transform.position.x < target.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (transform.position.x > target.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    // �����ܵ��˺�ʱ����
    public void TakenDamage(int _amount)
    {
        isAttack = true; // ���õ������ڱ�����״̬
        StartCoroutine(IsAttackCo()); // ����������Э��
        hp -= _amount; // ���ٵ��˵�����ֵ

        // ������˵�����ֵС�ڵ���0
        if (hp <= 0)
        {
            float dropChance = 0.1f; // ����ѪҺ�ĸ���
            float randomValue = Random.value; // ����һ�����ֵ
            if (randomValue <= dropChance)
            {
                Instantiate(bloodPrefab, transform.position, Quaternion.identity); // ����ѪҺ
            }
            EnemyPool.instance.Remove(this.gameObject); // �������ƻض����
            UIManager.instance.score++; // ���ӷ���
            UIManager.instance.UpdateScore(); // ���·�����ʾ
        }
    }

    // ������Э��
    private IEnumerator IsAttackCo()
    {
        yield return new WaitForSeconds(0.2f); // �ȴ�0.2��
        isAttack = false; // ���õ��˲��ٱ�����״̬
    }
}
