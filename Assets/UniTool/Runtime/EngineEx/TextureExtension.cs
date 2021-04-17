using UniTool.ObjectEx;
using UnityEngine;

namespace UniTool.EngineEx
{
    public static class TextureExtension
    {
        /// <summary>GameObject に MeshRenderer を追加する</summary>
        public static MeshRenderer AddMeshRenderer(this GameObject gameObject) => gameObject.AddComponent<MeshRenderer>();
        
        /// <summary>GameObject から MeshRenderer を取得する</summary>
        public static MeshRenderer GetMeshRenderer(this GameObject gameObject) => gameObject.GetComponent<MeshRenderer>();

        /// <summary>MeshRenderer から Texture を取得する</summary>
        public static Texture GetTexture(this MeshRenderer meshRenderer)
        { 
            var material = meshRenderer.material;
            return material.mainTexture;
        }
        
        /// <summary>MeshRenderer に Texture を差し替える</summary>
        public static MeshRenderer SetTexture(this MeshRenderer meshRenderer, Texture texture)
        { 
            var material = meshRenderer.material;
            material.mainTexture = texture;
            meshRenderer.material = material;
            return meshRenderer;
        }
        
        /// <summary>MeshRenderer から Color を取得する</summary>
        public static Color? GetColor(this MeshRenderer meshRenderer)
        { 
            var material = meshRenderer.material;
            return material.color;
        }
        
        /// <summary>MeshRenderer に Color を差し替える</summary>
        public static MeshRenderer SetColor(this MeshRenderer meshRenderer, Color color)
        { 
            var material = meshRenderer.material;
            material.color = color;
            meshRenderer.material = material;
            return meshRenderer;
        }
        
        /// <summary>GameObject から MeshFilter を追加する</summary>
        public static MeshFilter AddMeshFilter(this GameObject gameObject) => gameObject.AddComponent<MeshFilter>();

        /// <summary>GameObject から MeshFilter を取得する</summary>
        public static MeshFilter GetMeshFilter(this GameObject gameObject) => gameObject.GetComponent<MeshFilter>();
        
        /// <summary>MeshFilter の Mesh を差し替える</summary>
        public static MeshFilter SetMesh(this MeshFilter meshFilter, Mesh mesh) => meshFilter.Apply(it => it.sharedMesh = mesh);
    }
}