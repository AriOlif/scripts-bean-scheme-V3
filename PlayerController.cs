using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody PlayerRb;
    private float speed = 10;
    private float turnspeed = 150;
    private float horizontalInput;
    private float forwardInput;

    public float jumpForce = 10;
    public float gravityModifier;
    public float playerJumpHeight = 2;
    //public float playerSetX;
	//public float playerSetY;
	//public float playerSetZ;
    public bool isOnGround = true;
    
    

    //public Text Beans;


    public int CanOfBeans;
    public TextMeshProUGUI Beans;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        Beans.text = "CAN O' BEANS: " + CanOfBeans;
        PlayerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        //textbox = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //moves the player 
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");



        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnspeed * horizontalInput);

        //if it falls to the floor, it goes back to the start

        if(transform.position.y < -6)
        {
            transform.position = new Vector3(53, 10, 0);
        }

        //lets the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        {
           isOnGround = false;
           PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}

        //Debug.Log("Can O' Beans " + CanOfBeans);
    }

    // this code does diffrent stuff depending on what you collied with
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
        }else if(collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = new Vector3(53, 10, 0);
        }else if(collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            CanOfBeans = 0;
            UpdateBean(pointValue);
        }

    }

    public void UpdateBean(int scoreUp){
        CanOfBeans += scoreUp;
         Beans.text = "CAN O' BEANS: " + CanOfBeans;
    }

}
