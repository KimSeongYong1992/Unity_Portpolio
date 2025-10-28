using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class UIModule_Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject joystickBack;
    public GameObject joystickButton;

    public PlayerController playerController;

    private Vector2 originPos;
    private Vector2 touchPos;
    private float radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originPos = joystickBack.transform.position;
        radius = joystickBack.transform.GetComponent<RectTransform>().sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        joystickBack.transform.position = eventData.position;
        joystickButton.transform.position = eventData.position;
        touchPos = eventData.position;
        playerController.InputJoystickDir(Vector2.zero);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickBack.transform.position = originPos;
        joystickButton.transform.position = originPos;
        touchPos = originPos;
        playerController.InputJoystickDir(Vector2.zero);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchDirec = eventData.position - touchPos;

        float moveDist = Mathf.Min(touchDirec.magnitude, radius);
        Vector2 moveDir = touchDirec.normalized;
        Vector2 newPosition = touchPos + (moveDir * moveDist);
        joystickButton.transform.position = newPosition;
        playerController.InputJoystickDir(moveDir);
    }
}
