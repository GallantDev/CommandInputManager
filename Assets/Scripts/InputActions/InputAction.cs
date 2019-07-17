using System;
using UnityEngine;

[Serializable]
public abstract class InputAction {
    [SerializeField] private GameState state;

    #region Properties
    public GameState State {
        get {
            return state;
        }

        set {
            state = value;
        }
    }
    #endregion
}