using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickUI : MonoBehaviour
{
    [SerializeField] RectTransform outline;
    [SerializeField] RectTransform dirPoint; 
    [SerializeField] RectTransform touchPoint;

    private InputAction click;
    private InputAction pointer;

    Vector3 startPos = Vector3.zero;

	private void Start()
	{
		click = Managers.Input.Click;
        pointer = Managers.Input.Pointer;

		click.performed += OnClick;
		click.canceled += OnClickRelase;
		pointer.performed += UpdateHandPosition;

		gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		click.performed -= OnClick;
		click.canceled -= OnClickRelase;
		pointer.performed -= UpdateHandPosition;
	}

	void OnClick(InputAction.CallbackContext obj)
    {
        startPos = Input.mousePosition;
		outline.localPosition = outline.parent.InverseTransformPoint(startPos);
		touchPoint.localPosition = touchPoint.parent.InverseTransformPoint(startPos);
		dirPoint.localPosition = Vector3.zero;
		
		gameObject.SetActive(true); 
	}

	void OnClickRelase(InputAction.CallbackContext obj)
    {
		gameObject.SetActive(false);
	}

	void UpdateHandPosition(InputAction.CallbackContext obj)
    { 
		Vector3 curPos = obj.ReadValue<Vector2>();
		touchPoint.localPosition = touchPoint.parent.InverseTransformPoint(curPos);

		Vector3 dir = (curPos - startPos).normalized;
		dirPoint.localPosition = dir * 30;

	}
}
