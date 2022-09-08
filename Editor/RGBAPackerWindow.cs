using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using RGBAPacker.Common;

namespace RGBAPacker
{
    public class RGBAPackerWindow : EditorWindow
    {
        private Packer m_rgbaPacker = new Packer();
        private static Vector2 m_windowDimensions = new Vector2(250, 685);
        private Texture2D m_tex;

        [MenuItem("Window/RGBA Packer")]
        public static void ShowWindow()
        {
            var window = GetWindow<RGBAPackerWindow>("RGBA Packer");
            window.minSize = m_windowDimensions;
            window.maxSize = m_windowDimensions;
        }

        private void OnGUI()
        {
            m_rgbaPacker.packedTextureResolution = EditorGUI.Vector2IntField(new Rect(0,0,150,150), " Output resolution", m_rgbaPacker.packedTextureResolution);
            EditorGUILayout.Space(40);
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            m_rgbaPacker.channelRedTexture = (Texture2D)EditorGUILayout.ObjectField("Red", m_rgbaPacker.channelRedTexture, typeof(Texture2D), false);
            m_rgbaPacker.isChannelRedInverted = EditorGUILayout.Toggle("Invert channel red", m_rgbaPacker.isChannelRedInverted);
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            m_rgbaPacker.channelBlueTexture = (Texture2D)EditorGUILayout.ObjectField("Green", m_rgbaPacker.channelBlueTexture, typeof(Texture2D), false);
            m_rgbaPacker.isChannelGreenInverted = EditorGUILayout.Toggle("Invert channel green", m_rgbaPacker.isChannelGreenInverted);
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            m_rgbaPacker.channelGreenTexture = (Texture2D)EditorGUILayout.ObjectField("Blue", m_rgbaPacker.channelGreenTexture, typeof(Texture2D), false);
            m_rgbaPacker.isChannelBlueInverted = EditorGUILayout.Toggle("Invert channel blue", m_rgbaPacker.isChannelBlueInverted);
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            m_rgbaPacker.channelAlphaTexture = (Texture2D)EditorGUILayout.ObjectField("Alpha", m_rgbaPacker.channelAlphaTexture, typeof(Texture2D), false);
            m_rgbaPacker.isChannelAlphaInverted = EditorGUILayout.Toggle("Invert channel alpha", m_rgbaPacker.isChannelAlphaInverted);
            EditorGUILayout.Space();

            GUILayout.BeginHorizontal("box");
            GUILayout.FlexibleSpace();
            GUILayout.Label("Packed Texture");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.Space(136);

            GUI.DrawTexture(new Rect(65, 505, 128, 128), m_tex);

            if (GUILayout.Button("Pack the textures"))
            {
                m_tex = m_rgbaPacker.calculatePackedTexture();
            }
            if (GUILayout.Button("Save the packed texture"))
            {
                TextureSaver.saveTextureAsPNG(ref m_tex);
            }
        }
    }
}
