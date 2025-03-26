using UnityEngine;

public class Shadow : MonoBehaviour
{
    private GameObject player;
    public float TwSpeed = 10;

    void Start()
    {
        
    }


    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //쉐도우가 플레이어 따라가기
        transform.position = Vector3.Lerp(transform.position,player.transform.position, TwSpeed * Time.deltaTime);        //Lerp는 멀리있으면 속도가빨라지다가 가까이 와지면 속도가 느려집니다
    }
}
