using UnityEngine;
using UI_Inputs.Enums;

namespace UI_Inputs
{
    public class UI_InputJoystick : MonoBehaviour
    {
        [Header("---------Joystick Action---------")]
        [SerializeField]
        private JoyStickAction _joystickAction = JoyStickAction.Movement;

        public JoyStickAction idJoystick => _joystickAction;

        private Joystick thisJoystick;

        private void Awake()
        {
            GetJoystick();
        }

        void GetJoystick()
        {
            thisJoystick = GetComponent<Joystick>();

            if (thisJoystick == null)
                Debug.LogError("Couldn't find a joystick in: " + gameObject.name);
        }

        public Vector2 JoystickDirection()
        {
            if (thisJoystick == null)
                return Vector2.zero;

            return thisJoystick.Direction;
        }

        private void OnDisable()
        {
            if (thisJoystick != null)
                thisJoystick.ResetJoystick();
        }
    }
}