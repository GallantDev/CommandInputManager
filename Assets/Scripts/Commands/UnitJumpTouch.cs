using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitJumpTouch : Command {
    private Unit unit;
    private Touch touch;

    public UnitJumpTouch(Unit u, Touch t) {
        unit = u;
        touch = t;
    }

    public override void Execute() {
        Touch[] touches = Input.touches;
        if (touches.Length == 2) {
            unit.Jump();
        }
    }
}
