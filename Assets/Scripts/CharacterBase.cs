using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static WalkState;
//using UnityEngine.TextCore.Text;

public class CharacterBase : MonoBehaviour
{
    public enum Arrow
    {
        Invalide = -1,
        Left,
        Up,
        Right,
        Down
    }
    public Arrow Arrows;

    public bool IsPushedSpase = false;

    private Animator characterAnimator = null;

    private Vector3Int previousVector3;

    private const string Walk = "Walk";

    private const string Attack = "Attack";

    private void Awake()
    {
        characterAnimator = this.gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
        //characterAnimator.SetBool(Attack, false);
        //characterAnimator.SetTrigger("Clicked");

        var FloorToIntPos = Vector3Int.FloorToInt(this.transform.position);
        if (this.transform.position != FloorToIntPos)
        {
            this.transform.position = FloorToIntPos;
        }

        switch (Arrows)
        {
            case Arrow.Invalide:
                break;

            case Arrow.Left:
                // ���Ɉړ�
                if (CheckPos(FloorToIntPos += Vector3Int.left))
                {
                    this.transform.position += Vector3Int.left;
                    AnimationExecution(Walk, Vector3Int.left);
                    previousVector3 = Vector3Int.left;
                    characterAnimator.SetBool(Attack, false);
                    characterAnimator.SetTrigger("Clicked");
                }
                break;

            case Arrow.Up:
                // ��Ɉړ�
                if (CheckPos(FloorToIntPos += Vector3Int.up))
                {
                    this.transform.position += Vector3Int.up;
                    AnimationExecution(Walk, Vector3Int.up);
                    previousVector3 = Vector3Int.up;
                    characterAnimator.SetBool(Attack, false);
                    characterAnimator.SetTrigger("Clicked");
                }
                break;

            case Arrow.Right:
                // ���Ɉړ�
                if (CheckPos(FloorToIntPos += Vector3Int.right))
                {
                    this.transform.position += Vector3Int.right;
                    AnimationExecution(Walk, Vector3Int.right);
                    previousVector3 = Vector3Int.right;
                    characterAnimator.SetBool(Attack, false);
                    characterAnimator.SetTrigger("Clicked");
                }
                break;

            case Arrow.Down:
                // ���Ɉړ�
                if (CheckPos(FloorToIntPos += Vector3Int.down))
                {
                    this.transform.position += Vector3Int.down;
                    AnimationExecution(Walk, Vector3Int.down);
                    previousVector3 = Vector3Int.down;
                    characterAnimator.SetBool(Attack, false);
                    characterAnimator.SetTrigger("Clicked");
                }
                break;
        }
        Arrows = Arrow.Invalide;

        Vector3Int curVector3 = previousVector3;
        if (IsPushedSpase)
        {
            AnimationExecution(Attack, curVector3);
            Debug.Log("IsIs");
            
        }
        IsPushedSpase = false;

    }

    protected void SetArrowState(Arrow arrow)
    {
        Arrows = arrow;
    }

    protected void SetSpaceState(bool isPushed)
    {
        IsPushedSpase = isPushed;
    }

    private void AnimationExecution(string animationName, Vector3Int direction)
    {
        characterAnimator.SetBool(animationName, true);
        characterAnimator.SetFloat("X", direction.x);
        characterAnimator.SetFloat("Y", direction.y);
        characterAnimator.SetTrigger("Clicked");
    }

    // �i�ސ�ɕǂ��Ȃ������`�F�b�N����
    private bool CheckPos(Vector3 vec)
    {
        if (MapGenerator.map[(int)vec.x, (int)vec.y] == 1)
        {
            return false;
        }
        return true;
    }

}
