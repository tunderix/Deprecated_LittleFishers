using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

[System.Serializable]
public class BackpackInventoryItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;

    private Image imageComponent;
    private Sprite defaultIcon;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        imageComponent = GetComponent<Image>();
        string defaultIconPrefabPath = "Assets/Graphics/Textures/wooden_box.png";
        Texture2D icon = (Texture2D)AssetDatabase.LoadAssetAtPath(defaultIconPrefabPath, typeof(Texture2D)) as Texture2D;
        defaultIcon = Sprite.Create(icon, new Rect(0, 0, icon.width, icon.height), Vector2.zero);
    }

    void Start()
    {
        imageComponent.sprite = defaultIcon;
    }

    public void SetImage(Sprite icon)
    {
        imageComponent.sprite = icon;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
