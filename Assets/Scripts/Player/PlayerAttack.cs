using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public float rotZ; // ��������ת�Ƕ�
    public GameObject Weapon; // ��������
    private SpriteRenderer sp; // ������SpriteRenderer���
    private Animator anim; // ����ֱ۵Ķ������
    public bool isSwordAttack; // �Ƿ����ڽ��н�����

    public AudioClip bulletClip, swordClip; // �ӵ��ͽ�����Ч

    private void Start()
    {
        sp = Weapon.GetComponent<SpriteRenderer>(); // ��ȡ������SpriteRenderer���
        anim = transform.GetChild(0).GetComponent<Animator>(); // ��ȡ����ֱ۵Ķ������

        isSwordAttack = true; // ��ʼ״̬Ϊ���Խ��н�����
    }

    private void Update()
    {
        Attack(); // ���ʹ���������
        HandWeapon(); // ���������ĳ���
    }

    // �������߼�
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0)) // �������������
        {
            WeaponManager weaponManager = Weapon.GetComponent<WeaponManager>(); // ��ȡ�������������

            // �������λ�������λ�õĲ�����
            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            // ������������ת�Ƕ�
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; 

            // �����ǰ�����ǽ��ҿ��Խ��н�����
            if (sp.sprite.name == weaponManager.weaponSprite[0].name && isSwordAttack)
            {
                transform.GetChild(1).gameObject.SetActive(true); // �����������
                isSwordAttack = false; // ����Ϊ�����Խ��н�����
                anim.enabled = true; // ���ö���
                playSfx(swordClip); // ���Ž�������Ч
            }

            // �����ǰ������ǹ
            if (sp.sprite.name == weaponManager.weaponSprite[1].name)
            {
                BullectPool.instance.Get(); // ���ӵ����л�ȡ�ӵ�
                playSfx(bulletClip); // �����ӵ���Ч
            }
        }
    }

    // ���������ĳ���
    public void HandWeapon()
    {
        // �������λ�������λ�õĲ�����
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        float HandWeaponRotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; // ������������ת�Ƕ�
        Weapon.transform.rotation = Quaternion.Euler(0, 0, HandWeaponRotZ - 45); // ������������ת�Ƕ�
    }

    // ������Ч
    public void playSfx(AudioClip _clip)
    {
        GetComponent<AudioSource>().clip = _clip; // ������Ч����
        GetComponent<AudioSource>().Play(); // ������Ч
    }
}

