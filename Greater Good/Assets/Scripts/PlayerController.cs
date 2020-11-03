using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ExampleStruct
{
    public int structInt;
    public string structString;
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float sprintSpeed = 15;
    [SerializeField] float rotateSpeed = 10;
    [SerializeField] float maxStamina = 5;
    [SerializeField] float staminaRegen = 0.5f;
    [SerializeField] float staminaRegenDelay = 1;
    [SerializeField] ExampleStruct exampleStruct;
    public float stamina;
    bool sprintCooledDown = true;

    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        if(stamina > 0 && Input.GetKey(KeyCode.LeftShift) && sprintCooledDown && (horizontalMovement != 0 || verticalMovement != 0))
		{
            GetComponent<Rigidbody>().MovePosition(transform.position + (new Vector3(horizontalMovement, 0, verticalMovement).normalized * sprintSpeed * Time.fixedDeltaTime));
            stamina -= Time.fixedDeltaTime;
        }
		else
		{
            if (stamina == 0 && sprintCooledDown) StartCoroutine(StaminaRegenDelay());
            GetComponent<Rigidbody>().MovePosition(transform.position + (new Vector3(horizontalMovement, 0, verticalMovement).normalized * moveSpeed * Time.fixedDeltaTime));
            if (stamina < maxStamina) { stamina += staminaRegen * Time.fixedDeltaTime; }
        }

        Vector3 temp = Input.mousePosition;
        temp.z = temp.y;
        temp = Camera.main.ScreenToWorldPoint(temp);
        temp.y = transform.position.y;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(temp - transform.position), rotateSpeed);
    }

    IEnumerator StaminaRegenDelay()
	{
        sprintCooledDown = false;
        yield return new WaitForSeconds(staminaRegenDelay);
        sprintCooledDown = true;
	}
}
