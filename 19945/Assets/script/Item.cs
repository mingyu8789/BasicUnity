using UnityEngine;

public class Item : MonoBehaviour
{
    //아이템 가속 속도
    public float ItemVelocity = 20f;
    Rigidbody2D rig = null;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }


    void Update()
    {

    }


    ////아이템에서 플레이어 함수를 호출하는 방법!
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        collision.gameObject.SendMessageUpwards("PowerUp");
    //        Destroy(gameObject);
    //    }
    //}
}
