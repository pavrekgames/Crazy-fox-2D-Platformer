using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimer : Enemy
{
    [SerializeField] private Rigidbody2D slimerRigidbody;
    [SerializeField] private float jumpHeight = 3f;

    private void Start()
    {
        InvokeRepeating("Jump", 0f, 2);
    }

    protected override void Update()
    {
        base.Update();
    }

    private void Jump()
    {
        slimerRigidbody.velocity = new Vector2(0, jumpHeight);
    }

}
