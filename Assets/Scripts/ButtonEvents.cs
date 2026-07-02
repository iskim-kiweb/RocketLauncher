using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TouchButtonType
{
    Left,
    Right,
    Top,
    Botton,
    Fire01,
    Fire02,
    Fire03,
    Fire04
}

public class ButtonEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TouchButtonType buttonType;
    private Rocket rocket;
    private bool isFire01Holding = false;
    private bool isLeftHolding = false;
    private bool isRightHolding = false;
    private void Awake()
    {
        rocket = GetComponentInParent<Rocket>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("버튼 눌림 " + buttonType.ToString());

        switch(buttonType)
        {
            case TouchButtonType.Left:
                isLeftHolding = true;
                break;
            case TouchButtonType.Right:
                isRightHolding = true;
                rocket.PressedRightRotationButton();
                break;
            case TouchButtonType.Fire01:
                isFire01Holding = true;
                rocket.PressedThrustButton();
                break;               
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("버튼 뗌 " + buttonType.ToString());
        switch (buttonType)
        {
            case TouchButtonType.Left:
                isLeftHolding = false;
                rocket.ReleaseThrustButton();
                break;
            case TouchButtonType.Right:
                isRightHolding = false;
                break;
            case TouchButtonType.Fire01:
                isFire01Holding = false;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (isLeftHolding)
        {
            rocket.PressedLeftRotationButton();
        }
        else if (isRightHolding)
        {
            rocket.PressedRightRotationButton();
        }
        else if (isFire01Holding)
        {
            rocket.PressedThrustButton();
        }
    }
}
