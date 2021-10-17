using System.Collections.Generic;
using UI_Inputs.Tools;
using UnityEngine;

namespace UI_InputSystem.Base
{
    public static class UIInputsFinder
    {
        public static Dictionary<TInputAction, TInputType> GetAvailableInputs<TInputAction, TInputType, TInputValue>() where TInputType : UIInput<TInputAction, TInputValue>
        {
            var newInputs = new Dictionary<TInputAction, TInputType>();
            var availableInputsOfThisType = GetObjectsOfType<TInputType>();

            foreach (var inputType in availableInputsOfThisType)
            {
                if (newInputs.ContainsKey(inputType.InputID))
                {   
                    Debug.LogError($"Duplicates of {inputType.InputID} InputAction on gameObject {inputType.gameObject.name}! \n Please use only 1 input for each action!");
                    continue;
                }
                newInputs.Add(inputType.InputID, inputType);
            }
            return newInputs;
        }

        private static T[] GetObjectsOfType<T>() where T : Object
        {
            return Resources.FindObjectsOfTypeAll<T>();
        }
    }
}