using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class the_purple : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private Direction currDir;

    enum Direction
    {

        Forward,
        Backward,
        Left,
        Right
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Debug.Log(navMeshAgent);
        anim = GetComponent<Animator>();
        Debug.Log(anim);
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;
    }

    private void Update()
    {
        //Debug.Log(navMeshAgent.velocity);
        AnimController();
    }
    void AnimController()
    {
        var right = navMeshAgent.velocity.x;
        var forward = -navMeshAgent.velocity.z;
        bool isAbsMax = Mathf.Abs(right) > Mathf.Abs(forward);
        bool isMoving;

        currDir = GetDirection();
        string animationName = GetAnimationName(currDir);
        anim.Play(animationName);

        Direction GetDirection()
        {
            isMoving = true;
            if (right == 0 && forward == 0)
            {
                isMoving = false;
                return currDir;
            }
            else if (right == 0 && forward > 0)
            {
                currDir = Direction.Forward;
                return Direction.Forward;
            }
            else if (right == 0 && forward < 0)
            {
                currDir = Direction.Backward;
                return Direction.Backward;
            }
            else if (right < 0 && forward == 0)
            {
                currDir = Direction.Left;
                return Direction.Left;
            }
            else if (right > 0 && forward == 0)
            {
                currDir = Direction.Right;
                return Direction.Right;
            }
            else
            {
                if (isAbsMax)
                {
                    if (right > 0)
                    {
                        currDir = Direction.Right;
                        return Direction.Right;
                    }
                    else
                    {
                        currDir = Direction.Left;
                        return Direction.Left;
                    }
                }
                else
                {
                    if (forward > 0)
                    {
                        currDir = Direction.Forward;
                        return Direction.Forward;
                    }
                    else
                    {
                        currDir = Direction.Backward;
                        return Direction.Backward;
                    }
                }
            }
        }

        string GetAnimationName(Direction direction)
        {
            if(isMoving)
            switch (direction)
            {
                case Direction.Forward:
                    return "forward_run";
                case Direction.Backward:
                    return "back_run";
                case Direction.Left:
                    return "left_run";
                case Direction.Right:
                    return "right_run";
                default:
                    return "forward_idle";
            }
            else return $"{currDir.ToString().ToLower()}_idle";
        }
    }
}
