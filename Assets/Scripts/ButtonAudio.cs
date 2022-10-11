using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonAudio : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
       GameEvent.AudioSobitie(1);
    }
}
