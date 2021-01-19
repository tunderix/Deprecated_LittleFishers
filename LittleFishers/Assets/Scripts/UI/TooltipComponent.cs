using UnityEngine;
using TMPro;

namespace LittleFishers.UI
{
    public class TooltipComponent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;
        [SerializeField] private RectTransform backgroundImage;

        public void SetText(string text)
        {
            label.text = text;
        }

        public float PreferredHeight { get => label.preferredHeight; }
        public float PreferredWidth { get => label.preferredWidth; }

        public void SetBackgroundSize(Vector2 backgroundSize)
        {
            backgroundImage.sizeDelta = backgroundSize;
        }
    }
}
