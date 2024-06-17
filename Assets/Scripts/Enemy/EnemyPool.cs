using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    // ����ģʽ���������������
    public static EnemyPool instance;

    // �������ɵ��˵�Ԥ����
    public GameObject Object;

    // ���˵ĸ����壬������֯��νṹ
    public Transform parent;

    // ���ڴ洢���˵Ķ����
    public Queue<GameObject> objectPool = new Queue<GameObject>();

    // ��ʼ���ɵĵ�������
    public int startCount = 20;

    // ����������������������
    public int maxCount = 100;

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
            // ʵ��������Ԥ���壬�������丸����
            obj = Instantiate(Object, this.transform);
            obj.transform.parent = parent;
            // ��������ӵ�������У�������Ϊ������״̬
            objectPool.Enqueue(obj);
            obj.SetActive(false);
        }
    }

    // �Ӷ�����л�ȡһ������
    public GameObject Get()
    {
        GameObject tmp;
        if (objectPool.Count > 0)
        {
            // �����������е��ˣ���ȡ��һ����������
            tmp = objectPool.Dequeue();
            tmp.SetActive(true);
        }
        else
        {
            // ��������Ϊ�գ���ʵ����һ���µĵ���
            tmp = Instantiate(Object, this.transform);
            tmp.transform.parent = parent;
        }
        return tmp;
    }

    // �������ƻض����
    public void Remove(GameObject obj)
    {
        if (objectPool.Count < maxCount)
        {
            // ��������δ�ﵽ����������Ҷ�����в������õ��ˣ�����Żض���ز�����Ϊ������״̬
            if (!objectPool.Contains(obj))
            {
                objectPool.Enqueue(obj);
                obj.SetActive(false);
            }
        }
        else
        {
            // �������������������ٸõ���
            Destroy(obj);
        }
    }
}
