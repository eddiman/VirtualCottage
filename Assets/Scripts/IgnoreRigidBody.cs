using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRigidBody : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("IgnorePlayerCollision"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
    }
