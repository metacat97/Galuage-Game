using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = default;
    private Rigidbody eBulletRigid= default;

    // Start is called before the first frame update
    void Start()
    {
        eBulletRigid = GetComponent<Rigidbody>();
        eBulletRigid.velocity = transform.forward*speed;
        Destroy(gameObject, 7f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("총알이 플레이어와 만났다");
            PlayerController PlayerController = other.GetComponent<PlayerController>();
            if (PlayerController != null)
            {
                PlayerController.Die();
            }
        }
            PlayerBullet playerbullet = other.GetComponent<PlayerBullet>();
            if (playerbullet != null )
            {
                playerbullet.Die();
            }

    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

}
