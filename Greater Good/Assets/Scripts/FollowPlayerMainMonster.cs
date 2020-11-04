using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerMainMonster: MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector3 targetPosition;


    // Update is called once per frame
    void Update()
    {
        transform.Translate((targetPosition - transform.position).normalized * moveSpeed * Time.deltaTime);

        transform.LookAt(targetPosition);
    }

    public void UpdateTarget(Vector3 updatedPosition)
    {
        targetPosition = updatedPosition;
    }
}
