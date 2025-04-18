using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public float speed = 5f;    //λ―Έμ¬?Ό ??
    public float lifeTime = 3f; //λ―Έμ¬?Ό ?μ‘? ?κ°?
    public int damage = 10;     //λ―Έμ¬?Ό ?°λ―Έμ??
    private Vector2 direction;  //λ―Έμ¬?Ό ?΄? λ°©ν₯
   

    void Start()
    {
        Destroy(gameObject, lifeTime);  //?Ό?  ?κ°? ? λ―Έμ¬?Ό ? κ±?     
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
            //?¬κΈ°μ ?? ?΄?΄ ?°λ―Έμ?? λ‘μ§ μΆκ??
            Destroy(gameObject);
        }//? κ³? μΆ©λ???
        else if(other.CompareTag("Enemy"))
        {
            ShootingEnemy enemy = other.GetComponent<ShootingEnemy>();
            if(enemy != null)
            {
                enemy.PlayDeathAnimation();
            }

            //λ―Έμ¬?Ό ? κ±?
            Destroy(gameObject);
        }
    }



}