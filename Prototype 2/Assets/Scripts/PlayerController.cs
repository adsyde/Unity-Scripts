using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20.0f;
    public float xRange = 15.0f;
    public float zMinRange = 0;
    public float zMaxRange = 15.0f;
    public GameObject projectileObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zMinRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zMinRange);
        }

        if (transform.position.z > zMaxRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMaxRange);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectime from the player
            Instantiate(projectileObject, transform.position, projectileObject.transform.rotation);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }
}
