using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Kite;

namespace KitePlayTests {

  [TestFixture]
  public class RaycastHitResolverTest {

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

    [Test]
    public void CannotMoveDownWhenStandingOnCollider() {
      var goPosition = new Vector2(0, 1);
      var go = SetupCollider(
        name: "go",
        layer: 0,
        position: goPosition,
        size: Vector2.one * 2
      );
      var raycastHitResolver = new RaycasterHitResolver(
        transform: go.GetComponent<Transform>(),
        boxCollider: go.GetComponent<BoxCollider2D>(),
        Physics2D.GetLayerCollisionMask(go.layer)
      );

      var hitPosition = new Vector2(0, -1);
      var floor = SetupCollider(
        name: "floor",
        layer: 1,
        position: hitPosition,
        size: new Vector2(10, 2)
      );

      float allowedMoveDown = raycastHitResolver.ResolveAllowedDistance(2, Direction4.Down, goPosition);
      Assert.That(allowedMoveDown, Is.EqualTo(0));
    }

    [Test]
    public void CanMoveVerticallyWhenStandingOnCollider() {
      var goPosition = new Vector2(0, 1);
      var go = SetupCollider(
        name: "go",
        layer: 0,
        position: goPosition,
        size: Vector2.one * 2
      );
      var raycastHitResolver = new RaycasterHitResolver(
        transform: go.GetComponent<Transform>(),
        boxCollider: go.GetComponent<BoxCollider2D>(),
        Physics2D.GetLayerCollisionMask(go.layer)
      );

      var hitPosition = new Vector2(0, -1);
      var floor = SetupCollider(
        name: "floor",
        layer: 1,
        position: hitPosition,
        size: new Vector2(10, 2)
      );

      float exptecedVerticalMove = 2;

      float allowedMoveLeft = raycastHitResolver.ResolveAllowedDistance(exptecedVerticalMove, Direction4.Left, goPosition);
      Assert.That(allowedMoveLeft, Is.EqualTo(exptecedVerticalMove));

      float allowedMoveRight = raycastHitResolver.ResolveAllowedDistance(exptecedVerticalMove, Direction4.Right, goPosition);
      Assert.That(allowedMoveRight, Is.EqualTo(exptecedVerticalMove));
    }

    [Test]
    public void WhenColliderAllowReturnWholeDistance() {
      float distanceToMove = 5;

      var go = SetupCollider(
        name: "go",
        layer: 0,
        position: Vector2.zero,
        size: Vector2.one * 2
      );
      var raycastHitResolver = new RaycasterHitResolver(
        transform: go.GetComponent<Transform>(),
        boxCollider: go.GetComponent<BoxCollider2D>(),
        Physics2D.GetLayerCollisionMask(go.layer)
      );

      var hitPosition = new Vector2(2, 0);
      var hitGo = SetupCollider(
        name: "hitGo",
        layer: 1,
        position: hitPosition,
        size: Vector2.one * 2
      );
      var movingCollidable = hitGo.AddComponent<MovingCollidable>();
      movingCollidable.AllowedMove = Vector2.right * distanceToMove;

      Physics2D.IgnoreLayerCollision(0, 0, true);
      Physics2D.IgnoreLayerCollision(0, 1, false);
      var hit = Physics2D.Raycast(new Vector2(0, 1), Vector2.right, 5, Physics2D.GetLayerCollisionMask(go.layer));

      Assert.That(hit.collider, Is.EqualTo(hitGo.GetComponent<BoxCollider2D>()));
      Assert.That(hit.transform.GetComponent<ICollidable>(), Is.EqualTo(movingCollidable));

      float allowedDistance = raycastHitResolver.ResolveAllowedDistance(distanceToMove, Direction4.Right, Vector2.zero);
      Assert.That(allowedDistance, Is.EqualTo(distanceToMove));
    }
  }
}
