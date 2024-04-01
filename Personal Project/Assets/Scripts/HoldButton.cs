using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onButtonDown;
    public UnityEvent onButtonUp;

    private bool isButtonPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonPressed = true;
        onButtonDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonPressed = false;
        onButtonUp?.Invoke();
    }

    public bool IsButtonPressed()
    {
        return isButtonPressed;
    }
}
