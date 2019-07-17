using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveAxis : Command {
    private Unit unit = null;
    private Vector3 direction = Vector3.zero;
    private float axisValue = 0.0f;

    public UnitMoveAxis(Unit u, Vector3 dir, float axis) {
        unit = u;
        direction = dir;
        axisValue = axis;
    }

    public override void Execute() {
        unit.Move(direction * Mathf.Abs(axisValue));
    }
}