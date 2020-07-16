using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameJam1920.Assets.Scripts.Contracts
{
    public interface IInteractable
    {
        void Interact(Vector2 mousePositionInWorldSpace);
    }
}
