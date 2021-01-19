using UnityEngine;
using UnityEngine.EventSystems;

namespace LittleFishers.LFInventory
{
    [RequireComponent(typeof(CanvasGroup), typeof(RectTransform))]
    public class UI_DraggableBehaviour : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private bool _isDraggable;
        private CanvasGroup _canvasGroup;
        private RectTransform _rectTransform;
        private Vector3 _startPosition;
        private Transform _startParent;
        private bool _draggingEffectsEnabled
        {
            get => _draggingEffectsEnabled;
            set
            {
                SetDraggingEffects(value);
                _draggingEffectsEnabled = value;
            }
        }

        private void SetDraggingEffects(bool enabled)
        {
            _canvasGroup.alpha = enabled ? 0.5f : 1.0f;
            _canvasGroup.blocksRaycasts = !enabled;
        }

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _rectTransform = GetComponent<RectTransform>();
            _isDraggable = false;
        }

        public bool IsDraggable { get => _isDraggable; set => _isDraggable = value; }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!_isDraggable) return;

            _draggingEffectsEnabled = true;
            _startPosition = transform.position;
            _startParent = transform.parent;

            this.transform.SetParent(transform.root);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isDraggable) return;

            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!_isDraggable) return;

            _draggingEffectsEnabled = false;
            if (transform.parent != _startParent || transform.parent == transform.root)
            {
                transform.position = _startPosition;
                transform.SetParent(_startParent);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }
    }
}
