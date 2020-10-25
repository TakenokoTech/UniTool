using System.Collections;
using NUnit.Framework;
using UniTool.EngineEx;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniTool.Tests.PlayMode.EngineEx
{
    public class TextureExtensionTest
    {
        [UnityTest]
        public IEnumerator GetterTest()
        {
            var gameObject = new GameObject();
            yield return null;
            var meshRenderer1 = gameObject.GetMeshRenderer();
            var meshFilter1 = gameObject.GetMeshFilter();
            Assert.Null(meshRenderer1);
            Assert.Null(meshFilter1);

            gameObject.AddMeshRenderer();
            yield return null;
            var meshRenderer2 = gameObject.GetMeshRenderer();
            Assert.NotNull(meshRenderer2);
            
            var meshFilter2 = gameObject.AddMeshFilter();
            yield return null;
            meshFilter2 = gameObject.GetMeshFilter();
            Assert.NotNull(meshFilter2);
        }

        [UnityTest]
        public IEnumerator SetTextureTest()
        {
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return null;
            var meshRenderer = gameObject.GetMeshRenderer();
            Assert.Null(meshRenderer.GetTexture());
            Assert.AreEqual(new Color(1F, 1F, 1F), meshRenderer.GetColor());

            meshRenderer = meshRenderer.SetTexture(new Texture2D(1, 1));
            yield return null;
            Assert.NotNull(meshRenderer.GetTexture());
            
            meshRenderer = meshRenderer.SetColor(new Color(1F, 0F, 0F));
            yield return null;
            Assert.AreEqual(new Color(1F, 0F, 0F), meshRenderer.GetColor());
        }
        
        [UnityTest]
        public IEnumerator SetMeshTest()
        {
            var mesh = new Mesh();
            var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return null;
            var meshFilter = gameObject.GetMeshFilter();
            Assert.AreNotEqual(mesh, meshFilter.sharedMesh);
            
            meshFilter = meshFilter.SetMesh(mesh);
            yield return null;
            Assert.AreEqual(mesh, meshFilter.sharedMesh);
        }
    }
}