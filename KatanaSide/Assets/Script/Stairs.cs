using UnityEngine;

public class Stairs : MonoBehaviour
{
    //충돌처리
    //trigger 충돌이 일어났을대 통과
    //Collision충돌이 일어났을때 통과 X


    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)  //닿으면 중력 없음
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)   //나가면 중력 있음
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }





}
