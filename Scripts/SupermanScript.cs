using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupermanScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flyingStrength;
    public LogicManagerScript logic;
    public bool supermanIsAlive = true;
    private int n = 0;

    [SerializeField]
    private float maxAngle;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    public void UpdateSupermanAngle()
    {
        if (supermanIsAlive)
        {
            //Get  percentage of speed
            float percentage = Mathf.InverseLerp(-flyingStrength, flyingStrength, myRigidBody.velocity.y);

            //Determines value of angle
            float angle = Mathf.Lerp(-maxAngle, maxAngle, percentage);

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && supermanIsAlive==true)
        {
            myRigidBody.velocity = Vector2.up * flyingStrength;
            SoundManagerScript.PlaySound("Jump");
        }

        if(myRigidBody.transform.position.y > 15)
        {
            GameOver();
        }

        if (myRigidBody.transform.position.y < -15)
        {
            GameOver();
        }


        UpdateSupermanAngle();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void GameOver()
    {
        if (n == 0)
        {
            SoundManagerScript.PlaySound("Dead");
            n++;
        }
        logic.gameOver();
        supermanIsAlive = false;
    }
}
