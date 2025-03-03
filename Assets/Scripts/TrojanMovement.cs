using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrojanMovement : FlyingProjectile
{
    [SerializeField] float radius = 2f;
    [SerializeField] float angularSpeed = 3f;

    private float posX = 0f;
    private float posY = 0f;
    private float angle = 0f;
    private bool isMoveAround = false;
    private bool isFinishMoving = false;
    private float fixedAngle = 0f;

    private void Update()
    {
        if (isMoveAround && !isFinishMoving)
        {
            if (angle < fixedAngle + Mathf.PI)
            {
                moveCircle();
            }
            else
            {
                AimAtTarget(target);
                Moving();
                isFinishMoving = true;
            }
        }
        else if (Vector2.Distance(transform.position, target.transform.position) < radius && !isMoveAround)
        {
            isMoveAround = true;
            rb.velocity = Vector2.zero;
            fixedAngle = angle;
        }
    }

    public override void AimAtTarget(Transform target)
    {
        Vector2 targetDirection = transform.position - target.position;
        float angleT = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleT + 180);
        angle = ( Mathf.PI / 180 ) * Vector2.SignedAngle(transform.right, Vector2.right);
    }

    public override void Moving()
    {
        rb.velocity = transform.right * speed;
    }

    private void moveCircle()
    {
        posX = target.position.x + Mathf.Cos(Mathf.PI - angle) * radius;
        posY = target.position.y + Mathf.Sin(Mathf.PI - angle) * radius;
        transform.position = new Vector2(posX, posY);
        angle += Time.deltaTime * angularSpeed;
    }
}
