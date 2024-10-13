using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected enum UnitState { Idle, RightWalk, LeftWalk, Attack };
    protected UnitState unitState;
    
    [SerializeField]
    protected float speed;

    private void FixedUpdate()
    {
        switch(unitState)
        {
            case UnitState.RightWalk:
                transform.position += Vector3.right * speed * 0.01f;
                break;
            case UnitState.LeftWalk:
                transform.position += Vector3.left * speed * 0.01f;
                break;
        }
    }

    public void SetIdle()
    {
        unitState = UnitState.Idle;
        this.GetComponent<Animator>().SetTrigger("IdleTrigger");
    }

    public void SetRightWalk()
    {
        GetComponent<SpriteRenderer>().flipX = false;
        unitState = UnitState.RightWalk;
        this.GetComponent<Animator>().SetTrigger("WalkTrigger");
    }
    public void SetLeftWalk()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        unitState = UnitState.LeftWalk;
        this.GetComponent<Animator>().SetTrigger("WalkTrigger");
    }

    public void SetAttack()
    {
        unitState = UnitState.Attack;
        this.GetComponent<Animator>().SetTrigger("AttackTrigger");
    }
}
