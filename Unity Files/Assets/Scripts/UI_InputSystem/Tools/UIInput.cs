using UnityEngine;

namespace UI_Inputs.Tools
{
    public abstract class UIInput<TInputAction, TInputValue> : MonoBehaviour
    {
        public virtual TInputAction InputID { get; private set; }
        public virtual TInputValue InputValue { get; private set; }
        public virtual TInputValue InputDefaultValue { get; private set; }
    }
}