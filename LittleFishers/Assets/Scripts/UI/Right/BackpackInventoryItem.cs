using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

[System.Serializable]
public class BackpackInventoryItem : MonoBehaviour
{
    public static GameObject item;

    private RectTransform rectTransform;
    private Vector3 startPosition;

    private Image imageComponent;
    private Sprite defaultIcon;
    private CanvasGroup canvasGroup;

    Transform startParent;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        imageComponent = GetComponent<Image>();
        string defaultIconPrefabPath = "Assets/Graphics/Textures/wooden_box.png";
        Texture2D icon = (Texture2D)AssetDatabase.LoadAssetAtPath(defaultIconPrefabPath, typeof(Texture2D)) as Texture2D;
        defaultIcon = Sprite.Create(icon, new Rect(0, 0, icon.width, icon.height), Vector2.zero);
    }

    void Start()
    {
        if (!imageComponent.sprite)
            imageComponent.sprite = defaultIcon;
    }

    public void SetImage(Sprite icon)
    {
        imageComponent.sprite = icon;
    }

    public void SetPositionTo(BackpackSlot slot)
    {
        transform.SetParent(slot.gameObject.transform);
        this.rectTransform.position = new Vector2(0, 0);
        this.imageComponent.sprite = slot.item.inventoryIcon;
        /*RectTransform slotPosition = slot.GetComponent<RectTransform>();
        Debug.Log("Slot Position: " + slotPosition.localPosition);
        //Vector2 position = LittleFishersHelpers.RectTransformToScreenSpace(slot.GetComponent<RectTransform>()).position;
        //this.rectTransform.anchorMin = 
        this.rectTransform.position = new Vector2(-slotPosition.localPosition.x, -slotPosition.localPosition.y);*/
    }
}
