using UnityEngine;
using UnityEngine.Windows;

namespace RGBAPacker.Common
{
    public class TextureSaver
    {
        public static bool saveTextureAsPNG(ref Texture2D texture)
        {
            byte[] bytes = texture.EncodeToPNG();
            var dirPath = Application.dataPath + "/../PackedImages/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            File.WriteAllBytes(dirPath + "packed.png", bytes);

            return true;
        }
    }
}
