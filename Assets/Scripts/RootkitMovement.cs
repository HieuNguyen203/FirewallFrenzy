using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RootkitMovement : FlyingProjectile
{
    [SerializeField] float waitTime = 1.5f;

    private float moveTimer = 0f;
    private int moveCoeff = 1;

    // Update is called once per frame
    void Update()
    {
        if(moveTimer > waitTime)
        {
            moveTimer = 0f;
            moveCoeff = Mathf.Abs(moveCoeff - 1);
            Moving();
        }
        else
        {
            moveTimer += Time.deltaTime;
        }
    }

    public override void Moving()
    {
        rb.velocity = moveCoeff * transform.up * speed;
    }
}
