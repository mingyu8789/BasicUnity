using UnityEngine;

public class bosshead : MonoBehaviour
{
    [SerializeField] //직렬화
    GameObject bossbullet; //보스미사일

    //애니메이션에서 함수사용하기
    public void RightDownLaunch()
    {
        GameObject go = Instantiate(bossbullet, transform.position, Quaternion.identity);

        go.GetComponent<bossbullet>().Move(new Vector2(1, -1));
    }



    public void LeftDownLaunch()
    {
        GameObject go = Instantiate(bossbullet, transform.position, Quaternion.identity);

        go.GetComponent<bossbullet>().Move(new Vector2(-1, -1));

    }

    public void DownLaunch()
    {
        GameObject go = Instantiate(bossbullet, transform.position, Quaternion.identity);

        go.GetComponent<bossbullet>().Move(new Vector2(0, -1));

    }
}
