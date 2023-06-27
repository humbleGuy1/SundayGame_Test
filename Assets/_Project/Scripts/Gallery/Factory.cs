using UnityEngine;

namespace SunGameStudio.Gallery
{
    public class Factory
    {
        public Sprite CreateSprite(Texture2D texture)
        {
            float offset = 0.5f;

            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * offset);
        }

        public TObject CreateObjectOfType<TObject>(TObject gameObject, Transform parent) where TObject : Object
        {
            return Object.Instantiate(gameObject, parent);
        }
    }
}

