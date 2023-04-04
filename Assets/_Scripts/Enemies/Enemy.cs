using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected float speed = 4f;

    [SerializeField] protected Transform[] points;

    public enum Points
    {
        Point1,
        Point2
    }

    public Points currentPoint;

    protected virtual void Update()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        Vector2 directionPoint0 = points[0].position - transform.position;
        Vector2 directionPoint1 = points[1].position - transform.position;

        switch (currentPoint)
        {
            case Points.Point1:
                transform.Translate(directionPoint0.normalized * speed * Time.deltaTime, Space.World);
                spriteRenderer.flipX = false;
                break;
            case Points.Point2:
                transform.Translate(directionPoint1.normalized * speed * Time.deltaTime, Space.World);
                spriteRenderer.flipX = true;
                break;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyPoint") && currentPoint == Points.Point1)
        {
            currentPoint = Points.Point2;
        }
        else if (collision.CompareTag("EnemyPoint") && currentPoint == Points.Point2)
        {
            currentPoint = Points.Point1;
        }
    }

}
