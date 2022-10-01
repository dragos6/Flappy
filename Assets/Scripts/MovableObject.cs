using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    [SerializeField] float platformSpeed = 5f;
    [SerializeField] float resetPosition = 17.74f;
    [SerializeField] Vector3 defaultPos;

    // Update is called once per frame
    protected virtual void Update()
    {
        if(!GameManager.instance.GameOver )
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * platformSpeed));
            if (transform.position.x > resetPosition)
            {
                transform.position = new Vector3(defaultPos.x, transform.position.y, transform.position.z);
            }
        }
    }
}
