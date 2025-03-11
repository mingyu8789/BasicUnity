using System.Linq.Expressions;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //몬스터가지고오기
    public GameObject enemy;
    public GameObject enemy2;

    
    //적을 생성하는 함수
    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f); //적이 나타날 x좌표를 랜덤으로 생성하기

        //적을 생성한다. randomX랜덤한 x값
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
        //SpawnEnemy 1초 0.5f
        InvokeRepeating("SpawnEnemy", 1, 0.5f);

        InvokeRepeating("SpawnEnemy2", 5, 3.0f);

    }
    


    void Update()
    {
        
    }
}
