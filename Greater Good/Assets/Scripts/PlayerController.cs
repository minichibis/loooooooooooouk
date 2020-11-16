using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float sprintSpeed = 15;
    [SerializeField] float rotateSpeed = 10;
    [SerializeField] float maxStamina = 5;
    [SerializeField] float staminaRegen = 0.5f;
    [SerializeField] float staminaRegenDelay = 1;
    [SerializeField] int hitPoints = 3;
    [SerializeField] bool isSprinting = false;
    public float stamina;
    public bool sprintCooledDown = true;

    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Monster Fist") { hitPoints--; }
        if (hitPoints == 0) { GameManager.instance.GameOver(); }
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
            isSprinting = true;
        }
		else
		{
            isSprinting = false;
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

    public bool IsItSprinting()
    {
        return isSprinting;
    }
}
