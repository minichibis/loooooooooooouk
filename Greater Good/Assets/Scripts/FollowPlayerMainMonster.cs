using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerMainMonster: MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector3 targetPosition;
   

    public GameObject currentTarget;
    GameObject tempTarget;
    List<GameObject> silhouetteInstances;
    public float timeBetweenSilhouettes=7f,timeHolder=7f;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetPosition);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        timeHolder -= 1 * Time.deltaTime;
    }

    public void UpdateTarget(Vector3 updatedPosition)
    {
        targetPosition = updatedPosition;

        if (timeHolder <= 0)
        {
            RevealTarget();

            timeHolder = timeBetweenSilhouettes;
        }
    }

    public void RevealTarget()
    {
        tempTarget = Instantiate(currentTarget, targetPosition, currentTarget.transform.rotation);
        silhouetteInstances.Add(tempTarget);
        StartCoroutine(FadeOverTime());
    }

    IEnumerator FadeOverTime()
    {
        yield return new WaitForSeconds(7f);
        Destroy(silhouetteInstances[0]);
    }
}
