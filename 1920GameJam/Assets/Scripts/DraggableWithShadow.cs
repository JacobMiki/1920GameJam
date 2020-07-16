using GameJam1920.Assets.Scripts.Contracts;
using UnityEngine;

namespace GameJam1920.Assets.Scripts
{
    public class DraggableWithShadow : MonoBehaviour, IDraggable
    {
        [SerializeField] private DropShadow _dropShadow;
        [SerializeField] private Vector2 _draggingShadowOffset;
        [SerializeField] private Rect _worldBoundaries = new Rect(-8f, -4.5f, 16f, 9f);


        private Vector3 _idleShadowOffset;
        private Vector2 _mouseOffset;

        public void DragStart(Vector2 mousePositionInWorldSpace)
        {
            _mouseOffset = (Vector2)transform.position - mousePositionInWorldSpace;
            _idleShadowOffset = _dropShadow.ShadowOffset;
            _dropShadow.ShadowOffset = new Vector3(_draggingShadowOffset.x, _draggingShadowOffset.y, _idleShadowOffset.z);
        }

        public void OnDrag(Vector2 mousePositionInWorldSpace)
        {
            var newPos = mousePositionInWorldSpace + _mouseOffset;
            if (!_worldBoundaries.Contains(newPos))
            {
                newPos = new Vector2(
                    Mathf.Clamp(newPos.x, _worldBoundaries.xMin, _worldBoundaries.xMax),
                    Mathf.Clamp(newPos.y, _worldBoundaries.yMin, _worldBoundaries.yMax)
                );
            }
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
            _dropShadow.ShadowOffset = new Vector3(_draggingShadowOffset.x, _draggingShadowOffset.y, _idleShadowOffset.z);

        }

        public void DragEnd(Vector2 mousePositionInWorldSpace)
        {
            _dropShadow.ShadowOffset = _idleShadowOffset;
        }


    }
}
