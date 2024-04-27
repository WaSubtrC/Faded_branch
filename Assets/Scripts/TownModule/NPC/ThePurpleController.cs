using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Faded.Town
{
    public class ThePurpleController : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private Animator anim;
        private Direction currDir = Direction.Forward;

        enum Direction
        {
            Forward,
            Back,
            Left,
            Right
        }

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
            navMeshAgent.updateUpAxis = false;
            navMeshAgent.updateRotation = false;
        }

        private void Update()
        {
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
            if (CheckAnimationExists(animationName))
                anim.Play(animationName);
            else Debug.LogError(animationName);
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
                    currDir = Direction.Back;
                    return Direction.Back;
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
                            currDir = Direction.Back;
                            return Direction.Back;
                        }
                    }
                }
            }

            string GetAnimationName(Direction direction)
            {
                if (isMoving)
                    switch (direction)
                    {
                        case Direction.Forward:
                            return "forward_run";
                        case Direction.Back:
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

        bool CheckAnimationExists(string animationName)
        {
            int layerIndex = 0;
            int stateHash = Animator.StringToHash(animationName);
            bool hasState = anim.HasState(layerIndex, stateHash);
            return hasState;
        }
    }

}
