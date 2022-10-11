using UnityEngine;
using UnityEngine.EventSystems;


   public class GreyCubik : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
   {
      private RectTransform _rectTransform;
      private Canvas _canvas;
      private CanvasGroup _canvasGroup;
      private void Start()
      {
         _rectTransform = GetComponent<RectTransform>();
         _canvas = GetComponentInParent<Canvas>();
         _canvasGroup = GetComponent<CanvasGroup>();
      }
      
      
      public void OnBeginDrag(PointerEventData eventData)
      {
         _canvasGroup.blocksRaycasts = false;
         var kubikParrent = _rectTransform.parent;
         kubikParrent.SetAsLastSibling();
      }
   
   
      public void OnDrag(PointerEventData eventData)
      {
         _rectTransform.anchoredPosition += eventData.delta/_canvas.scaleFactor;
      }


      public void OnEndDrag(PointerEventData eventData)
      {
         transform.localPosition = Vector3.zero;
         _canvasGroup.blocksRaycasts = true;
      }

   }

