using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody bulletRigidbody = default;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed; ;

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("내 총알이 무언가와 만났다.");
            //PlayerControler PlayerControler = other.GetComponent<PlayerControler>();
            //if (PlayerControler != null)
            //{
            //    PlayerControler.Die();
            //}
            
            EnemyBullet enemy = other.GetComponent<EnemyBullet>();
            if (enemy != null) 
            {
                enemy.Die();
            }

        }


    }

    public void Die()
    {
        gameObject.SetActive(false);

        
    }
}
