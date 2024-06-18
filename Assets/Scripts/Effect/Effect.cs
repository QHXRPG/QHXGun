using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Effect �����Ҫ���������ӵ�����ʱ��ʼ����λ�ú���ת�Ƕȣ�
/// ������λ����ʵ���ƶ��������������ײʱ�Ե�������˺�����ʾ�˺���ֵ��
/// </summary>
public class Effect : MonoBehaviour
{
    public float bullectSpeed; // �ӵ����ٶ�
    private Transform player; // ���Transform���
    private PlayerAttack playerAttack; // ��ҹ������

    [SerializeField] private int minAttack, maxAttack; // ��С����󹥻���
    public int attackDamage; // ��ǰ������

    public GameObject damageTextPrefab; // �˺��ı�Ԥ����
    public GameObject bulletPrefab; // �ӵ�Ԥ����

    // ����������ʱ����
    private void OnEnable()
    {
        StartCoroutine(DestoryBullect()); // ���������ӵ���Э��

        // ��ȡ��ҵ�Transform���
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // ���ӵ�λ������Ϊ���������λ��
        this.transform.position = player.transform.Find("Weapon").position;

        // ��ȡ��ҹ�������������ӵ�����ת�Ƕ�
        playerAttack = player.GetComponent<PlayerAttack>();
        transform.rotation = Quaternion.Euler(0, 0, playerAttack.rotZ);
    }

    // ÿ֡����ʱ����
    private void Update()
    {
        // �ƶ��ӵ�
        transform.Translate(transform.right * bullectSpeed * Time.deltaTime, Space.World);
    }

    // �����ӵ���Э��
    private IEnumerator DestoryBullect()
    {
        yield return new WaitForSeconds(5f); // �ȴ�5��������ӵ�
        BullectPool.instance.Remove(this.gameObject); // ���ӵ��ƻض����
    }

    // ���ӵ�������ײʱ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �����ײ�Ķ����ǵ���
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // ������ɹ�����
            attackDamage = Random.Range(minAttack, maxAttack);

            // ��ȡ���˵�ITakenDamage�ӿ�
            ITakenDamage enemy = collision.GetComponent<ITakenDamage>();
            
            // �Ե�������˺�
            enemy.TakenDamage(attackDamage);

            // ���ӵ��ƻض����
            BullectPool.instance.Remove(this.gameObject);

            // ��ʾ�˺���ֵ
            DamageNum damageNum = Instantiate(damageTextPrefab, collision.gameObject.transform.position, Quaternion.identity).GetComponent<DamageNum>();
            damageNum.ShowDamage(attackDamage);

            // �ڵ���λ�������ӵ�Ч��
            Instantiate(bulletPrefab, collision.gameObject.transform.position, Quaternion.identity);
        }
    }
}
