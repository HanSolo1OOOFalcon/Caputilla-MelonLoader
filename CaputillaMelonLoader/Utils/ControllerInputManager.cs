using UnityEngine;
using UnityEngine.XR;

namespace CaputillaMelonLoader.Utils
{
    public class ControllerInputManager : MonoBehaviour
    {
        public static ControllerInputManager instance;

        public enum InputType
        {
            LeftGrip, RightGrip,
            LeftTrigger, RightTrigger,
            LeftPrimaryButton, RightPrimaryButton,
            LeftSecondaryButton, RightSecondaryButton,
        }

        public enum StickTypes
        {
            LeftStickAxis, RightStickAxis,
        }

        private readonly Dictionary<InputType, bool> previousStates = new Dictionary<InputType, bool>();
        private readonly Dictionary<InputType, bool> currentStates = new Dictionary<InputType, bool>();

        void Start()
        {
            instance = this;

            foreach (InputType input in System.Enum.GetValues(typeof(InputType)))
            {
                previousStates[input] = false;
                currentStates[input] = false;
            }
        }

        void Update()
        {
            foreach (InputType input in System.Enum.GetValues(typeof(InputType)))
            {
                previousStates[input] = currentStates[input];
                currentStates[input] = GetInputRaw(input);
            }
        }

        private bool GetInputRaw(InputType wantedInput)
        {
            switch (wantedInput)
            {
                case InputType.LeftGrip:
                    return InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
                        .TryGetFeatureValue(CommonUsages.gripButton, out bool leftGrip) && leftGrip;
                case InputType.RightGrip:
                    return InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
                        .TryGetFeatureValue(CommonUsages.gripButton, out bool rightGrip) && rightGrip;
                case InputType.LeftTrigger:
                    return InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
                        .TryGetFeatureValue(CommonUsages.triggerButton, out bool leftTrigger) && leftTrigger;
                case InputType.RightTrigger:
                    return InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
                        .TryGetFeatureValue(CommonUsages.triggerButton, out bool rightTrigger) && rightTrigger;
                case InputType.LeftPrimaryButton:
                    return InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
                               .TryGetFeatureValue(CommonUsages.primaryButton, out bool leftPrimaryButton) &&
                           leftPrimaryButton;
                case InputType.RightPrimaryButton:
                    return InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
                               .TryGetFeatureValue(CommonUsages.primaryButton, out bool rightPrimaryButton) &&
                           rightPrimaryButton;
                case InputType.LeftSecondaryButton:
                    return InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
                               .TryGetFeatureValue(CommonUsages.secondaryButton, out bool leftSecondaryButton) &&
                           leftSecondaryButton;
                case InputType.RightSecondaryButton:
                    return InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
                               .TryGetFeatureValue(CommonUsages.secondaryButton, out bool rightSecondaryButton) &&
                           rightSecondaryButton;
            }

            return false;
        }

        public bool GetInput(InputType wantedInput)
        {
            return currentStates[wantedInput];
        }

        public bool GetInputDown(InputType wantedInput)
        {
            return currentStates[wantedInput] && !previousStates[wantedInput];
        }

        public bool GetInputUp(InputType wantedInput)
        {
            return !currentStates[wantedInput] && previousStates[wantedInput];
        }

        public Vector2 GetAxis(StickTypes wantedAxis)
        {
            switch (wantedAxis)
            {
                case StickTypes.LeftStickAxis:
                    InputDevices.GetDeviceAtXRNode(XRNode.LeftHand)
                        .TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 leftAxis);
                    return leftAxis;
                case StickTypes.RightStickAxis:
                    InputDevices.GetDeviceAtXRNode(XRNode.RightHand)
                        .TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 rightAxis);
                    return rightAxis;
            }

            return Vector2.zero;
        }
    }
}