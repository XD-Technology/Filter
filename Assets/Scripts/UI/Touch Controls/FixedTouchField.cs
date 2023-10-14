using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LastPlayer.Game
{
    public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        //[HideInInspector]
        public Vector2 TouchDist;

        //[HideInInspector]
        public bool Pressed;

        private Vector2 pointerOld;
        private int pointerId;

        void Update()
        {
            if (Pressed)
            {

                if (pointerId >= 0 && pointerId < Input.touches.Length)
                {
                    TouchDist = Input.touches[pointerId].position - pointerOld;
                    pointerOld = Input.touches[pointerId].position;
                }
                else
                {
                    TouchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointerOld;
                    pointerOld = Input.mousePosition;
                }
            }
            else
            {
                TouchDist = new Vector2();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed = true;
            pointerId = eventData.pointerId;
            pointerOld = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Pressed = false;
        }
    }
}