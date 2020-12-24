using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Kite;

namespace KitePlayTests {

  [TestFixture]
  public class CollidableHelpersTest {

    private List<GameObject> testGameObjects = new List<GameObject>();

    [OneTimeSetUp]
    public void OneTimeSetUp() {
      Physics2D.IgnoreLayerCollision(0, 0, true);
      Physics2D.IgnoreLayerCollision(0, 1, false);
    }

    [TearDown]
    public void TearDown() {
      foreach (var go in testGameObjects) {
        Object.Destroy(go);
      }
      testGameObjects.Clear();
    }

    GameObject SetupCollider(string name, int layer, Vector2 position, Vector2 size) {
      var go = new GameObject(name) {
        layer = layer
      };
      testGameObjects.Add(go);
      var transform = go.GetComponent<Transform>();
      transform.position = position;
      go.AddComponent<Rigidbody2D>();
      var boxCollider = go.AddComponent<BoxCollider2D>();
      boxCollider.size = size;
      return go;
    }


  }
}