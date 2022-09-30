using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObstacle : MovableObject
{
    [SerializeField] private Vector3 topPos;
    [SerializeField] private Vector3 bottomPos;
    [SerializeField] private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move(bottomPos));
    }
    protected override void Update()
    {
        base.Update();
    }
    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            Vector3 direction = target.y == topPos.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * Time.deltaTime * speed;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        Vector3 newTarget = target.y == topPos.y ? bottomPos : topPos;
        StartCoroutine(Move(newTarget));
    }
}
