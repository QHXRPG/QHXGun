using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{

    private Coroutine attackRoutine; // ����Э��

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

        // �������Ƿ�ס������������������갴ť��
        if (Input.GetMouseButton(0))
        {
            // �������Э��û������������������Э��
            if (attackRoutine == null)
            {
                attackRoutine = StartCoroutine(AttackCoroutine());
            }
        }
        else
        {
            // �������Э���Ѿ�������������Ѿ��ɿ���갴ť����ֹͣ����Э��
            if (attackRoutine != null)
            {
                StopCoroutine(attackRoutine);
                attackRoutine = null;
            }
        }
        HandWeapon(); // ���������ĳ���
    }

    IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Attack();

            // �ȴ�һ��ʱ�䣬ʱ�䳤���ɹ����ٶȾ���
            float waitTime = 1.0f / Globalx.GunSpeed;
            Debug.Log("waitTime:"+ waitTime + " GunSpeed:"+ Globalx.GunSpeed);
            yield return new WaitForSeconds(waitTime);
        }
    }

    // �������߼�
    public void Attack()
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
            //isSwordAttack = false; // ����Ϊ�����Խ��н�����
            anim.enabled = true; // ���ö���
            anim.speed = Globalx.SwordSpeed; // ���ö��������ٶ�
            playSfx(swordClip); // ���Ž�������Ч
        }

        // �����ǰ������ǹ
        if (sp.sprite.name == weaponManager.weaponSprite[1].name)
        {
            BullectPool.instance.Get(); // ���ӵ����л�ȡ�ӵ�
            playSfx(bulletClip); // �����ӵ���Ч
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
        StartCoroutine(PlaySfxCoroutine(_clip, 0.3f)); // ֻ����0.3��
    }

    private IEnumerator PlaySfxCoroutine(AudioClip clip, float duration)
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
            yield return new WaitForSeconds(duration);
            audioSource.Stop();
        }
        else
        {
            Debug.LogWarning("AudioSource component missing on the GameObject.");
        }
    }

    // һ�������������ⲿ�޸Ĺ����ٶ�
    public void SetAttackSpeed(float newAttackSpeed)
    {
        Globalx.GunSpeed = newAttackSpeed;
    }
}

