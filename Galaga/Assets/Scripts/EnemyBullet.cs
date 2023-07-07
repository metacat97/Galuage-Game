using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody eBulletRigid= default;
    public Transform Target;
    public int Hp = default;
    //public float Speed = 1f;
    public GameObject fire;
    

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);

        //transform.Translate(0, 0, 1);
        //transform.Translate(new Vector3(0f, -0.5f, 0f));
        eBulletRigid = GetComponent<Rigidbody>();
        eBulletRigid.velocity = transform.forward*speed;
        Destroy(gameObject, 10f);
        
    }
    private void Update()
    {
     // transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime *Speed);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //transform.Translate(new Vector3(0f, 0f, 10f), Space.Self);
       // transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 10.85f, 0), Time.deltaTime * Speed);

        if (other.tag == "Player")
        {
            //Debug.Log("ÃÑ¾ËÀÌ ÇÃ·¹ÀÌ¾î¿Í ¸¸³µ´Ù");
            PlayerController PlayerController = other.GetComponent<PlayerController>();
            if (PlayerController != null)
            {
                PlayerController.Die();
            }
        }
        PlayerBullet playerbullet = other.GetComponent<PlayerBullet>();
        if (playerbullet != null)
        {
            playerbullet.Die();
        }

    }

    public void Die()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.SetScore(10);
        GameObject Effect = Instantiate(fire,transform.position,transform.rotation);
        Destroy(Effect,1f);
        
        gameObject.SetActive(false);
        //Debug.Log("Àß Á×¿ò");
        
        
        //Debug.Log(gameManager.ScoreCount);
    }
  
}
