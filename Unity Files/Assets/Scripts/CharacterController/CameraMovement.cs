using UI_InputSystem.Base;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform, cameraTranform;

    [SerializeField]
    [Range(25f, 150f)]
    private float mouseSensX = 75f, mouseSensY = 75f;

    [SerializeField]
    private float minClampVertical = -60, maxClampHorizontal = 90;

    private float verticalRotation = 0;
    private float XValueWithSens => UIInputSystem.ME.GetAxisHorizontal(JoyStickAction.CameraLook) * Time.deltaTime * mouseSensX;
    private float YValueWithSens => UIInputSystem.ME.GetAxisVertical(JoyStickAction.CameraLook) * Time.deltaTime * mouseSensY;
    private float RotationClamped(float refRotation) => Mathf.Clamp(refRotation, minClampVertical, maxClampHorizontal);
    
    private void FixedUpdate()
    {
        CameraHorizontalMovement();
        CameraVerticalMovement();
    }

    private void CameraVerticalMovement()
    {
        if (!cameraTranform) return;
        
        verticalRotation -= YValueWithSens;
        verticalRotation = RotationClamped(verticalRotation);

        cameraTranform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    private void CameraHorizontalMovement()
    {
        if (playerTransform == null) return;

        playerTransform.Rotate(Vector3.up * XValueWithSens);
    }

    public void OverrideLookAt(Transform targetToLook) => cameraTranform.LookAt(targetToLook);
}