using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class InputHandler : MonoBehaviour {
    private class InputValueData {
        public KeyCode keyValue;
        public float axisValue;
        public Touch touchValue;

        public InputValueData(KeyCode key) {
            keyValue = key;
        }

        public InputValueData(float axisVal) {
            axisValue = axisVal;
        }

        public InputValueData(Touch touch) {
            touchValue = touch;
        }
    }

    private GameManager manager = null;
    DeviceType device;
    private List<KeyInput> keyActions = new List<KeyInput>();
    private List<AxisInput> axisActions = new List<AxisInput>();
    private List<TouchInput> touchActions = new List<TouchInput>();

    #region GameInputs

    #endregion

    #region Properties

    #endregion

    void Start () {
        Init();
    }

    private void Init() {
        manager = GameManager.Instance;
        device = SystemInfo.deviceType;
        InitializeInputLists();
    }

    void Update() {
        if (device == DeviceType.Handheld) {
            HandleTouchInputs();
        }
        else {
            HandleKeyInputs();
            HandleAxisInputs();
        }
    }

    private void InitializeInputLists() {
        FieldInfo[] tmpFields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        InputAction tmpInput;
        for (int i = 0; i < tmpFields.Length; i++) {
            if (tmpFields[i].FieldType.IsSubclassOf(typeof(InputAction))) {
                tmpInput = tmpFields[i].GetValue(this) as InputAction;
                if (tmpFields[i].FieldType == typeof(KeyInput)) {
                    keyActions.Add(tmpInput as KeyInput);
                }
                else if (tmpFields[i].FieldType == typeof(AxisInput)) {
                    axisActions.Add(tmpInput as AxisInput);
                }
                else if (tmpFields[i].FieldType == typeof(TouchInput)) {
                    touchActions.Add(tmpInput as TouchInput);
                }
            }
        }
    }

    private string GetAxisName(GameInputAxes axis) {
        switch (axis) {
            case GameInputAxes.HORIZONTAL:
            return "Horizontal";
            case GameInputAxes.VERTICAL:
            return "Vertical";
            case GameInputAxes.MOUSE_X:
            return "Mouse X";
            case GameInputAxes.MOUSE_Y:
            return "Mouse Y";
            case GameInputAxes.MOUSE_SCROLLWHEEL:
            return "Mouse ScrollWheel";
            default:
            throw new Exception("Input Axis not implemented!");
        }
    }

    private void HandleInputAction(InputAction action, InputValueData inputData) {
        if (manager.CurrentState == action.State) {

        }
    }

    private void HandleKeyInputs() {
        foreach (KeyInput keyAction in keyActions) {
            switch (keyAction.DetectionType) {
                case KeyDetectionType.PRESS:
                if (Input.GetKeyDown(keyAction.Key)) {
                    HandleInputAction(keyAction, new InputValueData(keyAction.Key));
                }
                break;
                case KeyDetectionType.HOLD:
                if (Input.GetKey(keyAction.Key)) {
                    HandleInputAction(keyAction, new InputValueData(keyAction.Key));
                }
                break;
                case KeyDetectionType.RELEASE:
                if (Input.GetKeyUp(keyAction.Key)) {
                    HandleInputAction(keyAction, new InputValueData(keyAction.Key));
                }
                break;
            }
        }
    }

    private void HandleAxisInputs() {
        foreach (AxisInput axisAction in axisActions) {
            switch (axisAction.DetectionType) {
                case AxisDetectionType.POSITIVE:
                if (axisAction.UseRawAxisInput) {
                    if (Input.GetAxisRaw(GetAxisName(axisAction.InputAxis)) == 1.0f) {
                        HandleInputAction(axisAction, new InputValueData(Input.GetAxisRaw(GetAxisName(axisAction.InputAxis))));
                    }
                }
                else {
                    if (Input.GetAxis(GetAxisName(axisAction.InputAxis)) > 0.0f) {
                        HandleInputAction(axisAction, new InputValueData(Input.GetAxis(GetAxisName(axisAction.InputAxis))));
                    }
                }
                break;
                case AxisDetectionType.NEGATIVE:
                if (axisAction.UseRawAxisInput) {
                    if (Input.GetAxisRaw(GetAxisName(axisAction.InputAxis)) == -1.0f) {
                        HandleInputAction(axisAction, new InputValueData(Input.GetAxisRaw(GetAxisName(axisAction.InputAxis))));
                    }
                }
                else {
                    if (Input.GetAxis(GetAxisName(axisAction.InputAxis)) < 0.0f) {
                        HandleInputAction(axisAction, new InputValueData(Input.GetAxis(GetAxisName(axisAction.InputAxis))));
                    }
                }
                break;
                case AxisDetectionType.BOTH:
                if (axisAction.UseRawAxisInput) {
                    if (Input.GetAxisRaw(GetAxisName(axisAction.InputAxis)) == 1.0f || Input.GetAxisRaw(GetAxisName(axisAction.InputAxis)) == -1.0f) {
                        HandleInputAction(axisAction, new InputValueData(Input.GetAxisRaw(GetAxisName(axisAction.InputAxis))));
                    }
                }
                else {
                    if (Input.GetAxis(GetAxisName(axisAction.InputAxis)) != 0.0f) {
                        HandleInputAction(axisAction, new InputValueData(Input.GetAxis(GetAxisName(axisAction.InputAxis))));
                    }
                }
                break;
            }
        }
    }

    private void HandleTouchInputs() {
        int touchCount = Input.touchCount;
        Touch[] touches = Input.touches;
        for (int i = 0; i < touchCount; i++) {
            foreach (TouchInput touchAction in touchActions) {
                if (touchCount == 1) {
                    if (touchAction.SoloTouchOnly && touchAction.DetectionType == touches[i].phase) {
                        HandleInputAction(touchAction, new InputValueData(touches[i]));
                    }
                }
                else {
                    if (!touchAction.SoloTouchOnly && touchAction.DetectionType == touches[i].phase) {
                        HandleInputAction(touchAction, new InputValueData(touches[i]));
                    }
                }
            }
        }
    }
}