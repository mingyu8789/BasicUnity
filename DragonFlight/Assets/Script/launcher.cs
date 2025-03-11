using UnityEngine;

public class launcher : MonoBehaviour
{
    public GameObject bullet;   //�̻��� ������ ������ ����

    void Start()
    {
        //InvokeRepeating(�Լ��̸�,�ʱ������ð�,������ �ð�)
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    void Shoot()
    {
        //�̻��� ������, ��ó������, ���Ⱚ ����
        Instantiate(bullet, transform.position, Quaternion.identity);   //Quaternion.identity �������� ������ �ֱ�

        //���� ����غ��� ����Ŵ������� �ѻ��� �ٷ� �����Լ� ȣ�� �̱�����
        SoundManager.instance.PlayBulletSound();
    }
  
    void Update()
    {
        
    }
}
