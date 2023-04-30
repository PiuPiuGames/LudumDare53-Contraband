using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;

    public Transform[] movePoints;
    private int targetPoint;

    public GameObject contrabandLaser;
    bool hasntDetected = true;

    private void Update()
    {
        if (hasntDetected) {
            Vector2 direction = (movePoints[targetPoint].position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, movePoints[targetPoint].position) < 0.1f)
            {
                targetPoint = (targetPoint + 1) % movePoints.Length;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject contrabandLaserObject = Instantiate(contrabandLaser, new Vector3(transform.position.x, transform.position.y - 3.7f, transform.position.z), Quaternion.identity);
        hasntDetected = false;
    }
}
