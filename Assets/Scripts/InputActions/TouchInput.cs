using System;
using UnityEngine;

[Serializable]
public class TouchInput : InputAction {
    [SerializeField] private TouchPhase detectionType;
    [SerializeField] private bool soloTouchOnly = false;

    #region Properties
    public TouchPhase DetectionType {
        get {
            return detectionType;
        }

        set {
            detectionType = value;
        }
    }

    public bool SoloTouchOnly {
        get {
            return soloTouchOnly;
        }

        set {
            soloTouchOnly = value;
        }
    }
    #endregion
}