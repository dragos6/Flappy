using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float resetPosition = 17.74f;
    [SerializeField] Vector3 defaultPos;

    // Update is called once per frame
    void Update()
    {
        Debug.Log((int)transform.localPosition.x);
        if(transform.position.x > resetPosition)
        {
            transform.position = defaultPos;
        }
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));

    }
}
