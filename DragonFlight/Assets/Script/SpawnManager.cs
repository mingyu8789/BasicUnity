using System.Linq.Expressions;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //���Ͱ��������
    public GameObject enemy;
    public GameObject enemy2;

    
    //���� �����ϴ� �Լ�
    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f); //���� ��Ÿ�� x��ǥ�� �������� �����ϱ�

        //���� �����Ѵ�. randomX������ x��
        Instantiate(enemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
    }

    void SpawnEnemy2()
    {
        float randomX = Random.Range(-2f, 2f);

        Instantiate(enemy2, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
    }

    void SpawnEnemy3()
    {
       
    }


    void Start()
    {
        //SpawnEnemy 1�� 0.5f
        InvokeRepeating("SpawnEnemy", 1, 0.5f);

        InvokeRepeating("SpawnEnemy2", 5, 3.0f);

    }
    


    void Update()
    {
        
    }
}
