using System.Collections;
using UnityEngine;

public class CorotineStudy : MonoBehaviour
{

    //  c# ����Ƽ �ڷ�ƾ(Coroutine) ����
    //�ڷ�ƾ�� �Ϲ����� �Լ��� �޸� ������ ����ٰ� �ٽ� �̾ ������ �� �ִ� ����̾�.
    //�̸� �̿��ϸ� ���� �ð� �� ����ǰų�, Ư�� ������ ��ٸ��� ���� ����� ���� ������ �� �־�!
   
    void Start()
    {
        StartCoroutine("ExampleCoroutine");
        StartCoroutine(ExampleCoroutine()); //�̸����� ���� �Լ��� ���� �����
    }

  
    IEnumerator ExampleCoroutine()
    {
        Debug.Log("�ڷ�ƾ ����");
        yield return new WaitForSeconds(2f);    //2�ʴ��
        Debug.Log("2�� �� ����");
    }

    //IEnumerator ExampleCoroutine()
    //{
    //    while (true)
    //    {
    //        Debug.Log("�� 1�ʸ��� ����");
    //        yield return new WaitForSeconds(1f);    //2�ʴ��
    //    }
    //}

}
