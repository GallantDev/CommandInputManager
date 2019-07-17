using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveTouch : Command
{
    private Unit unit;
    private Touch touch;

    public UnitMoveTouch(Unit u, Touch t) {
        unit = u;
        touch = t;
    }

    public override void Execute() {
        //Determine whether or not to move left or right
        float halfScreenThreshWidth = Screen.width / 2.0f;

        if (touch.position.x < halfScreenThreshWidth) {
            unit.Move(Vector3.left);
        }
        else if (touch.position.x > halfScreenThreshWidth) {
            unit.Move(Vector3.right);
        }
    }
}