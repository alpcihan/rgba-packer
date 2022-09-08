using UnityEngine;

namespace RGBAPacker.Common
{
    public static class TextureConverter
    {
        public static Texture2D renderTextureToTexture2D(RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
            var oldRTex = RenderTexture.active;
            RenderTexture.active = rTex;

            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();

            RenderTexture.active = oldRTex;
            return tex;
        }
    }
}
