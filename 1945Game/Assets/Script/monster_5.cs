using UnityEngine;

public class monster_5 : MonoBehaviour
{
    public float Speed = 3;
    public float Delay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject bullet;


    void Start()
    {
        //�ѹ��Լ�ȣ��
        Invoke("CreateBullet", Delay);
    }


    void CreateBullet()
    {
        Instantiate(bullet, ms1.position, Quaternion.identity);
        Instantiate(bullet, ms2.position, Quaternion.identity);

        //���ȣ��
        Invoke("CreateBullet", Delay);  //start�� �� �� ȣ������� �� ��ɾ �ѹ� �� ������ �� ��� �ݺ��ǰ� �Ѵ�
    }











  
    void Update()
    {
        //�Ʒ� �������� ��������
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);   
    }

}
