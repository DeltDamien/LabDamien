using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public BallData BallData;
    public string TagWall;
    public string TagBar;


    public void OnCollisionEnter(Collision collision)
    {
        CollisionWall(collision);
        CollisionBar(collision);
    }

    public void CollisionWall(Collision collision)
    {
        if (collision.gameObject.tag == TagWall)
        {
            if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x - 0.2f) <= 0.2f)
            {
                bool right = Random.Range(-1.0f, 1.0f) >= 0;
                GetComponent<Rigidbody>().AddForce(new Vector2(right ? 5.0f : -5.0f, 0), ForceMode.Impulse);
            }
            if (Mathf.Abs(GetComponent<Rigidbody>().velocity.y - 0.2f) <= 0.2f)
            {
                bool down = Random.Range(-1.0f, 1.0f) >= 0;
                GetComponent<Rigidbody>().AddForce(new Vector2(0, down ? 5.0f : -5.0f), ForceMode.Impulse);
            }
        }
    }

    public void CollisionBar(Collision collision)
    {
        if (collision.gameObject.tag == TagBar)
        {
            Vector2 hitPos = collision.gameObject.transform.position;
            Vector2 ballPos = gameObject.transform.position;

            Vector2 delta = ballPos - hitPos;
            Vector2 direction = delta.normalized;
            Debug.Log("");
            GetComponent<Rigidbody>().velocity = direction * BallData.speedBall;
        }
    }
}