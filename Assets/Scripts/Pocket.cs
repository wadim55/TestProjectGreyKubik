
using UnityEngine;
using UnityEngine.EventSystems;

public class Pocket : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var kubik = eventData.pointerDrag.transform;
        kubik.SetParent(transform);
        kubik.localPosition = Vector3.zero;
        GameEvent.Sobitie(gameObject.tag);
    }
    
}
