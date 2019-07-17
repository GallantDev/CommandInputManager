using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : Command
{
    public override void Execute() {
        GameManager.Instance.PauseGame();
    }
}
