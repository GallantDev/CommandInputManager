using System;
using UnityEngine;

[Serializable]
public class AxisInput : InputAction {
    [SerializeField] private GameInputAxes inputAxis;
    [SerializeField] private AxisDetectionType detectionType;
    [SerializeField] private bool useRawAxisInput = false;

    #region Properties
    public GameInputAxes InputAxis {
        get {
            return inputAxis;
        }

        set {
            inputAxis = value;
        }
    }

    public AxisDetectionType DetectionType {
        get {
            return detectionType;
        }

        set {
            detectionType = value;
        }
    }

    public bool UseRawAxisInput {
        get {
            return useRawAxisInput;
        }

        set {
            useRawAxisInput = value;
        }
    }
    #endregion
}
