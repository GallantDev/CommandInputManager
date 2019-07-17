using UnityEngine;

public class UnitMove : Command {
    private Unit unit = null;
    private Vector3 direction = Vector3.zero;

    public UnitMove(Unit u, Vector3 dir) {
        unit = u;
        direction = dir;
    }

    public override void Execute() {
        unit.Move(direction);
    }
}