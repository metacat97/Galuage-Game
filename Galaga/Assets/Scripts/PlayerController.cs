using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform bulletPool = default;
    public GameObject bulletPrefab;
    public Rigidbody PlayerRigid;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("키 입력 받았음");

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation, bulletPool);
        }
        float xInput = Input.GetAxis("Horizontal");
        float xspeed = xInput  * speed;

        Vector3 newVelocity = new Vector3(xspeed, 0f, 0f);

        PlayerRigid.velocity = newVelocity;
    }
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }    
}
