using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb; // ��ҵĸ������
    [HideInInspector] public float moveH, moveV; // ��ҵ�ˮƽ�ʹ�ֱ�ƶ��ٶ�

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ��ȡ��ҵĸ������
    }

    private void Update()
    {
        // ��ȡ��ҵ����룬�������ҵ��ƶ��ٶ�
        moveH = Input.GetAxis("Horizontal") * Globalx.moveSpeed;
        moveV = Input.GetAxis("Vertical") * Globalx.moveSpeed;

        // ������ҵ�λ�ú�����λ�ã���ת��ҵĳ���
        PlayerOverturn();
    }

    private void FixedUpdate()
    {
        // ʹ�ø�����ٶ����ԣ�ʵ����ҵ��ƶ�
        rb.velocity = new Vector2(moveH, moveV);
    }

    public void PlayerOverturn()
    {
        // �����ҵ�λ����������ߣ�����ҳ����ұ�
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        // �����ҵ�λ���������ұߣ�����ҳ������
        if (transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}

