using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.Translate((targetPosition - transform.position).normalized * moveSpeed * Time.deltaTime);
    }
}
