using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Vector3 moveDestnation = new Vector3(0f, 1f, 20f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Speed = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, moveDestnation, ref Speed, 0.5f);
    }
}
