using UnityEngine;

public class UnitJump : Command {
    private Unit unit = null;

    public UnitJump(Unit u) {
        unit = u;
    }

    public override void Execute() {
        unit.Jump();
    }
}