using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Faded.Town
{
    public class the_purple : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private Animator anim;
        private Direction currDir;

        enum Direction
        {
            Forward,
            back,
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
                    currDir = Direction.back;
                    return Direction.back;
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
                            currDir = Direction.back;
                            return Direction.back;
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
                        case Direction.back:
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
            // 获取动画层的索引，通常是0
            int layerIndex = 0;
            // 获取动画状态名称的哈希值
            int stateHash = Animator.StringToHash(animationName);
            // 检测动画状态是否存在
            bool hasState = anim.HasState(layerIndex, stateHash);
            return hasState;
        }
    }

}
