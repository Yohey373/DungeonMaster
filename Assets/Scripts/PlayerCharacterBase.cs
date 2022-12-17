using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterBase : CharacterBase
{
    // Start is called before the first frame update
    void Start()
    {

        this.transform.position = MapGenerator.Instance.StartPos;

        int num = 8;
        Debug.Log(num << 1);
        Debug.Log(num << 2);
        Debug.Log(num << 3);
        Debug.Log(num << 4);
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Input.anyKeyDown) {
            GameTurnManager.PlayerActionTurnExecution();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            base.SetArrowState(Arrow.Left);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            base.SetArrowState(Arrow.Up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            base.SetArrowState(Arrow.Down);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            base.SetArrowState(Arrow.Right);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            base.IsAttack = true;
        }
        base.Update();
    }
}
