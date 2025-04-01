using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    public float speed = 5f;    //ë¯¸ì‚¬?¼ ?†?„
    public float lifeTime = 3f; //ë¯¸ì‚¬?¼ ?ƒì¡? ?‹œê°?
    public int damage = 10;     //ë¯¸ì‚¬?¼ ?°ë¯¸ì??
    private Vector2 direction;  //ë¯¸ì‚¬?¼ ?´?™ ë°©í–¥
   

    void Start()
    {
        Destroy(gameObject, lifeTime);  //?¼? • ?‹œê°? ?›„ ë¯¸ì‚¬?¼ ? œê±?     
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
            //?—¬ê¸°ì— ?”Œ? ˆ?´?–´ ?°ë¯¸ì?? ë¡œì§ ì¶”ê??
            Destroy(gameObject);
        }//? ê³? ì¶©ëŒ?–ˆ?„?•Œ
        else if(other.CompareTag("Enemy"))
        {
            ShootingEnemy enemy = other.GetComponent<ShootingEnemy>();
            if(enemy != null)
            {
                enemy.PlayDeathAnimation();
            }

            //ë¯¸ì‚¬?¼ ? œê±?
            Destroy(gameObject);
        }
    }



}