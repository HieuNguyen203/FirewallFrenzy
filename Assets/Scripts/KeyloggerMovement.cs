using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyloggerMovement : FlyingProjectile
{
    public override void Moving()
    {
        rb.velocity = speed * Vector2.Distance(target.position, transform.position) * transform.up;
    }
}
