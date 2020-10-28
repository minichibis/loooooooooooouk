using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerMainMonster: MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((targetPosition - transform.position).normalized * moveSpeed * Time.deltaTime);
    }

    public void UpdateTarget(Vector3 updatedPosition)
    {
        targetPosition = updatedPosition;
    }
}
