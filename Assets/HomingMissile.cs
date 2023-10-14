using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float angleChangingSpeed;
    public float movementSpeed;

    private Transform target;
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Init(Transform t)
    {
        target = t;
    }

    void FixedUpdate()
    {
        Vector3 direction = target.position - rigidBody.position;
        direction.Normalize();
        Vector3 rotateAmount = Vector3.Cross(direction, transform.up);
        rigidBody.angularVelocity = -angleChangingSpeed * rotateAmount;
        rigidBody.velocity = transform.up * movementSpeed;
    }
}
