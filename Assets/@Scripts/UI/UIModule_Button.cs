using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.WSA;

using static Define;

public class UIModule_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private GameObject[] button;
    public PlayerController playerController;
    int iButtonCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iButtonCount = button.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        for (int i = 0; i < button.Length; ++i)
        {
            Vector2 touchVec = (Vector2)button[i].transform.position - eventData.position;
            float distance = Mathf.Sqrt(Mathf.Pow(touchVec.x, 2) + Mathf.Pow(touchVec.y, 2));
            float radius = button[i].transform.GetComponent<RectTransform>().rect.width;
            if (distance < radius) playerController.PressButton((PLAYBUTTON)i);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
