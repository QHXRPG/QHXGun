using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponManager : MonoBehaviour
{
    public Sprite[] weaponSprite; // �洢������Sprite����
    private SpriteRenderer sp; // ������SpriteRenderer���
    public bool isSword; // �Ƿ��ǽ�
    private Animator anim; // �����Ķ������

    public GameObject[] weaponObj; // �洢�������������

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>(); // ��ȡ������SpriteRenderer���
        anim = GetComponent<Animator>(); // ��ȡ�����Ķ������
    }

    private void Update()
    {
        // ���Q������
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("�л�����"); // ���������Ϣ

            // �����ǰ�����ǽ�
            if (!isSword)
            {
                sp.sprite = weaponSprite[0]; // �л�����Sprite
                isSword = true; // ����Ϊ��
                weaponObj[0].transform.localScale = new Vector3(0.6f, 0.6f, 0.6f); // �������Ĵ�С
                weaponObj[1].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // ����ǹ�Ĵ�С
            }
            else // �����ǰ������ǹ
            {
                sp.sprite = weaponSprite[1]; // �л�����Sprite
                isSword = false; // ����Ϊǹ
                weaponObj[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // �������Ĵ�С
                weaponObj[1].transform.localScale = new Vector3(0.6f, 0.6f, 0.6f); // ����ǹ�Ĵ�С
            };
        }
    }

    // ��������������
    public void EndSword()
    {
        anim.enabled = false; // ֹͣ����
    }
}

