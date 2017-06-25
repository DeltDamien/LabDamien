using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputBar : MonoBehaviour
{
    [Header("Player settings")]
    public float PlayerSpeed;
    public float LimitXLeft;
    public float LimitXRight;
    [Space(5)]


    [Header("Ball settings")]
    public GameObject Ball;
    public float BallImpulsion;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateRegularMovment();
        UpdateLaunchGame();
    }

    public void UpdateRegularMovment()
    {
        float translation = Input.GetAxis("Horizontal") * PlayerSpeed;
        translation *= Time.deltaTime;

        transform.Translate(translation, 0, 0);
        if (transform.position.x >= LimitXRight)
            transform.position = new Vector3(LimitXRight, transform.position.y, transform.position.z);
        else if (transform.position.x <= LimitXLeft)
            transform.position = new Vector3(LimitXLeft, transform.position.y, transform.position.z);
    }

    public void UpdateLaunchGame()
    {
        if (Ball != null)
        {
            if (transform.Find(Ball.name) != null && Input.GetButton("Jump"))
            {
                Ball.GetComponent<Rigidbody>().AddForce(Random.Range(-800, 800), BallImpulsion, 0);
                Ball.transform.parent = transform.parent;
            }
        }
    }
}
