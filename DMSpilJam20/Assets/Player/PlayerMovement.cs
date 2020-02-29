using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float lookDirection;
    public new Rigidbody2D rigidbody;
    Camera mainCamera;




    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        Movement();

        
    }

    void LookAtMouse()
    {
        Vector2 player2mouse = Input.mousePosition - mainCamera.WorldToScreenPoint(transform.position);
        lookDirection = Mathf.Atan2(player2mouse.y, player2mouse.x);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, lookDirection * Mathf.Rad2Deg);
    }

    void Movement()
    {
        if (Input.anyKey)
        {

            Vector3 playerDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            playerDir.Normalize();

            rigidbody.MovePosition(transform.position + playerDir * movementSpeed * Time.deltaTime);

            rigidbody.velocity = Vector3.zero;

            //transform.position += playerDir * movementSpeed * Time.deltaTime;

        }
    }
}
