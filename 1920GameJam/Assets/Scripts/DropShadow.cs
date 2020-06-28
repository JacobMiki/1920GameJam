using UnityEngine;

namespace GameJam1920.Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class DropShadow : MonoBehaviour
    {
        public Vector3 ShadowOffset;
        public Color ShadowColor;

        SpriteRenderer spriteRenderer;
        GameObject shadowGameobject;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            //create a new gameobject to be used as drop shadow
            shadowGameobject = new GameObject("Shadow");

            //create a new SpriteRenderer for Shadow gameobject
            var shadowSpriteRenderer = shadowGameobject.AddComponent<SpriteRenderer>();

            //set the shadow gameobject's sprite to the original sprite
            shadowSpriteRenderer.sprite = spriteRenderer.sprite;
            //set the shadow gameobject's material to the shadow material we created
            shadowSpriteRenderer.color = ShadowColor;

            //update the shadow to always lie behind the sprite
            shadowSpriteRenderer.transform.position = transform.position + ShadowOffset;
        }

        void LateUpdate()
        {
            //update the position and rotation of the sprite's shadow with moving sprite
            shadowGameobject.transform.position = transform.position + ShadowOffset;
            shadowGameobject.transform.localRotation = transform.localRotation;
        }
    }
}
