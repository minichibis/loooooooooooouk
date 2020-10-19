using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float rotateSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        GetComponent<Rigidbody>().MovePosition(transform.position + (new Vector3(horizontalMovement, 0, verticalMovement).normalized * moveSpeed * Time.fixedDeltaTime));


        Vector3 temp = Input.mousePosition;
        temp.z = temp.y;
        temp = Camera.main.ScreenToWorldPoint(temp);
        temp.y = transform.position.y;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(temp), rotateSpeed);
    }
}
