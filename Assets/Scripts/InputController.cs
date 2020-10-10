using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour, IDragHandler
{
    [SerializeField] private Vector2Event vector2Event;

    public void OnDrag(PointerEventData eventData)
    {
        vector2Event.Raise(eventData.delta.normalized);
    }
}
