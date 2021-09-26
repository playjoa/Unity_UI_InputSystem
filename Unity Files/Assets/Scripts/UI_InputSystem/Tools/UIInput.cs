using UnityEngine;

namespace UI_Inputs.Tools
{
    public abstract class UIInput<TInput> : MonoBehaviour
    {
        public virtual TInput InputID { get; private set; }
    }
}