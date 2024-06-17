using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullectPool : MonoBehaviour
{
    public static BullectPool instance; // ����ģʽ���������������

    public GameObject Object; // ���������ӵ���Ԥ����
    public Transform parent; // �ӵ��ĸ����壬������֯��νṹ

    // ���ڴ洢�ӵ��Ķ����
    public Queue<GameObject> objectPool = new Queue<GameObject>();

    // ��ʼ���ɵ��ӵ�����
    public int startCount = 16;

    // ����������������ӵ�����
    public int maxCount = 25;

    // �ڽű�ʵ����ʱ���ã���ʼ�������Ͷ����
    public void Awake()
    {
        instance = this;
        Init();
    }

    // ��ʼ�������
    public void Init()
    {
        GameObject obj;
        for (int i = 0; i < startCount; i++)
        {
            // ʵ�����ӵ�Ԥ���壬�������丸����
            obj = Instantiate(Object, this.transform);
            obj.transform.parent = parent;

            // ���ӵ���ӵ�������У�������Ϊ������״̬
            objectPool.Enqueue(obj);
            obj.SetActive(false);
        }
    }

    // �Ӷ�����л�ȡһ���ӵ�
    public GameObject Get()
    {
        GameObject tmp;
        if (objectPool.Count > 0)
        {
            // �������������ӵ�����ȡ��һ����������
            tmp = objectPool.Dequeue();
            tmp.SetActive(true);
        }
        else
        {
            // ��������Ϊ�գ���ʵ����һ���µ��ӵ�
            tmp = Instantiate(Object, this.transform);
            tmp.transform.parent = parent;
        }
        return tmp;
    }

    // ���ӵ��ƻض����
    public void Remove(GameObject obj)
    {
        if (objectPool.Count < maxCount)
        {
            // ��������δ�ﵽ����������Ҷ�����в��������ӵ�������Żض���ز�����Ϊ������״̬
            if (!objectPool.Contains(obj))
            {
                objectPool.Enqueue(obj);
                obj.SetActive(false);
            }
        }
        else
        {
            // �������������������ٸ��ӵ�
            Destroy(obj);
        }
    }
}
