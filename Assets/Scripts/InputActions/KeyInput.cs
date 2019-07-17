using System;
using UnityEngine;

[Serializable]
public class KeyInput : InputAction {
    [SerializeField] private KeyCode key;
    [SerializeField] private KeyDetectionType detectionType;

    #region Properties
    public KeyCode Key {
        get {
            return key;
        }

        set {
            key = value;
        }
    }

    public KeyDetectionType DetectionType {
        get {
            return detectionType;
        }

        set {
            detectionType = value;
        }
    }
    #endregion
}