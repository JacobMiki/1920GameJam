using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Contracts
{
    interface IDraggable
    {
        void DragStart(Vector2 mousePositionInWorldSpace);
        void OnDrag(Vector2 mousePositionInWorldSpace);
        void DragEnd(Vector2 mousePositionInWorldSpace);
    }
}
