using UnityEngine;
using TMPro;

namespace LittleFishers.UI
{
    public class TooltipController : MonoBehaviour
    {
        private static TooltipComponent instance;
        [SerializeField] private TooltipComponent tooltip;
        [SerializeField] private Camera uiCamera;
        [SerializeField] private Vector2 tooltipOffset;

        [SerializeField] private RectTransform backgroundRectTransform;

        private void Awake()
        {
            instance = tooltip;
        }

        private void Update()
        {
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(this.transform.parent.gameObject.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
            localPoint.x += tooltipOffset.x;
            localPoint.y += tooltipOffset.y;
            instance.gameObject.GetComponent<RectTransform>().localPosition = localPoint;
        }

        public static void ShowTooltip(string with)
        {
            instance.gameObject.SetActive(true);
            instance.SetText(with);
            float textPaddingSize = 4f;
            Vector2 backgroundSize = new Vector2(instance.PreferredWidth + textPaddingSize * 2f, instance.PreferredHeight + textPaddingSize * 2f);
            instance.SetBackgroundSize(backgroundSize);
        }

        public static void HideTooltip()
        {
            instance.gameObject.SetActive(false);
            instance.SetText("");
        }
    }
}
