using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public float speed = 5f;    //미사?�� ?��?��
    public float lifeTime = 3f; //미사?�� ?���? ?���?
    public int damage = 10;     //미사?�� ?��미�??
    private Vector2 direction;  //미사?�� ?��?�� 방향
   

    void Start()
    {
        Destroy(gameObject, lifeTime);  //?��?�� ?���? ?�� 미사?�� ?���?     
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }



    void Update()
    {
        float timeScale = TimeController.Instance.GetTimeScale();
        transform.Translate(direction * speed * Time.deltaTime* timeScale);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //?��기에 ?��?��?��?�� ?��미�?? 로직 추�??
            Destroy(gameObject);
        }//?���? 충돌?��?��?��
        else if(other.CompareTag("Enemy"))
        {
            ShootingEnemy enemy = other.GetComponent<ShootingEnemy>();
            if(enemy != null)
            {
                enemy.PlayDeathAnimation();
            }

            //미사?�� ?���?
            Destroy(gameObject);
        }
    }



}