using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RGBAPacker.Common;

namespace RGBAPacker
{
    public class Packer
    {
        public Texture2D channelRedTexture;
        public Texture2D channelGreenTexture;
        public Texture2D channelBlueTexture;
        public Texture2D channelAlphaTexture;
        public bool isChannelRedInverted = false;
        public bool isChannelGreenInverted = false;
        public bool isChannelBlueInverted = false;
        public bool isChannelAlphaInverted = false;
        public Vector2Int packedTextureResolution = new Vector2Int(128,128);

        public Texture2D calculatePackedTexture()
        { 
            // create render texture
            m_packedRenderTexture = new RenderTexture(packedTextureResolution.x, packedTextureResolution.y, 0);

            // compute
            setupMaterial();
            Graphics.Blit(null, m_packedRenderTexture, m_rgbaPackerMaterial);

            // return the result as texture2d
            return TextureConverter.renderTextureToTexture2D(m_packedRenderTexture);
        }

        private RenderTexture m_packedRenderTexture;
        private Material m_rgbaPackerMaterial = null;

        private void setupMaterial()
        {
            if(!m_rgbaPackerMaterial)
                m_rgbaPackerMaterial = new Material(Shader.Find("Unlit/RGBAPackerShader"));

            m_rgbaPackerMaterial.SetTexture("_ChannelRedTex", channelRedTexture);
            m_rgbaPackerMaterial.SetTexture("_ChannelGreenTex", channelGreenTexture);
            m_rgbaPackerMaterial.SetTexture("_ChannelBlueTex", channelBlueTexture);
            m_rgbaPackerMaterial.SetTexture("_ChannelAlphaTex", channelAlphaTexture);
            m_rgbaPackerMaterial.SetInt("_IsChannelRedInverted", isChannelRedInverted ? 1 : 0);
            m_rgbaPackerMaterial.SetInt("_IsChannelGreenInverted", isChannelGreenInverted ? 1 : 0);
            m_rgbaPackerMaterial.SetInt("_IsChannelBlueInverted", isChannelBlueInverted ? 1 : 0);
            m_rgbaPackerMaterial.SetInt("_IsChannelAlphaInverted", isChannelAlphaInverted ? 1 : 0);
        } 
    }
}
