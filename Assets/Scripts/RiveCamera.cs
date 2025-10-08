using UnityEngine;

public class RiveToSprite : MonoBehaviour
{
    public Camera riveCamera; // The dedicated camera rendering only the RiveWidget

    public Sprite CaptureToSprite()
    {
        RenderTexture rt = riveCamera.targetTexture;

        // Copy RT → Texture2D
        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGBA32, false);
        rt.useMipMap = false;
        rt.autoGenerateMips = false;
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply();
        RenderTexture.active = null;

        // Convert Texture2D → Sprite
        return Sprite.Create(
            tex,
            new Rect(0, 0, tex.width, tex.height),
            new Vector2(0.5f, 0.5f),
            100f // pixels per unit
        );
    }
}
