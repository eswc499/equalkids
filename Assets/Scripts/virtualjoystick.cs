using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class virtualjoystick : MonoBehaviour, IDragHandler, IPointerUpHandler,IPointerDownHandler {

    private Image bgimg;
    private Image joystick;
    private Vector3 inputVector;
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgimg.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / bgimg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgimg.rectTransform.sizeDelta.y);
            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (bgimg.rectTransform.sizeDelta.x / 3)
                , inputVector.z * (bgimg.rectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
    public float Horizontal()
    {if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");

    }

    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");

    }



    // Use this for initialization
    void Start () {

        bgimg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
