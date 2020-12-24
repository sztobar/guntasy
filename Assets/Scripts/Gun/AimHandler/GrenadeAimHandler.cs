using UnityEngine;
using Kite;

public class GrenadeAimHandler : BaseWeaponAimHandler {

  [SerializeField]
  private CircleCollider2D aimDeadzone;

  [SerializeField]
  private WeaponDirection3Handler weaponDirection3Handler;

  [SerializeField]
  private float focusedAimScale = 1f;

  [SerializeField]
  private Transform shootAnchor;

  [SerializeField]
  private float rotationSpeed;

  [SerializeField]
  private GrenadeMovement grenadeMovementPrefab;

  [SerializeField]
  private GrenadeAimPreview aimPreview;

  [SerializeField]
  [Range(0, 1)]
  private float viewportAimX;

  [SerializeField]
  [Range(0, 1)]
  private float viewportAimY;

  private PlayerCameraConfiner playerCamera;
  private PlayerDodgeComponent playerDodge;
  private IWeaponAnimator weaponAnimator;
  private Vector2 mouseToWeaponDelta;
  private Vector2 lastMousePositionToDeadzone = Vector2.zero;
  private Vector2 projectileDirection;
  private CursorManager aimCursorManager;

  public override Vector2 MousePosition => mouseToWeaponDelta + (Vector2)transform.position;

  public override void FocusAim(bool focus) {
    if (focus) {
      playerCamera.SetConfinerScale(focusedAimScale);
    } else {
      playerCamera.ResetConfinerScale();
    }
  }

  private void OnEnable() {
    aimCursorManager = CursorManager.Instance;
    aimCursorManager.CursorConfiner.SetViewportConfiner(new Vector2(viewportAimX, viewportAimY));
  }

  private void OnDisable() {
    aimCursorManager.CursorConfiner.ResetViewportConfiner();
  }

  public override Direction3 GetDirection3() {
    return weaponDirection3Handler.GetDirection3();
  }

  public override Quaternion GetFireRotation() {
    return Quaternion.LookRotation(Vector3.forward, projectileDirection) * Quaternion.Euler(0, 0, 90);
  }

  public override void Inject(IWeaponDI di) {
    weaponAnimator = di.WeaponAnimator;
    playerCamera = di.PlayerDI.Camera;
    playerDodge = di.PlayerDI.GameplayController.Dodge;
    weaponDirection3Handler.Inject(di);
  }

  public override bool LookAt(Vector2 newMousePosition) {
    if (IsInDeadzone(newMousePosition)) {
      if (lastMousePositionToDeadzone == Vector2.zero) {
        Vector2 deadzoneToMouseDirection = (newMousePosition - (Vector2)aimDeadzone.transform.position).normalized;
        lastMousePositionToDeadzone = deadzoneToMouseDirection * aimDeadzone.radius;
        mouseToWeaponDelta = lastMousePositionToDeadzone + (Vector2)aimDeadzone.transform.position - (Vector2)transform.position;
        AimUpdate();
        return true;
      }
      aimCursorManager.SetWorldPosition((Vector2)aimDeadzone.transform.position + lastMousePositionToDeadzone);
      AimUpdate();
      return false;
    } else {
      aimCursorManager.SetWorldPosition(newMousePosition);
      lastMousePositionToDeadzone = Vector2.zero;
      mouseToWeaponDelta = newMousePosition - (Vector2)transform.position;
      AimUpdate();
      return true;
    }
  }

  private void Update() {
    if (playerDodge.IsDodging()) {
      weaponDirection3Handler.Reset();
      transform.localRotation = Quaternion.identity;
    } else if (weaponAnimator.IsReloading()) {
      transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.identity, Time.deltaTime * rotationSpeed);
      weaponDirection3Handler.Reset();
    } else {
      transform.rotation = GetWeaponRotation(projectileDirection);
      weaponDirection3Handler.SetDirection(Vector2Extensions.QuaternionToVector2(transform.rotation));
    }
  }

  private void AimUpdate() {
    Vector2 shootAnchorPosition = shootAnchor.position;
    Vector2 mouseToShootPositionDelta = MousePosition - shootAnchorPosition;
    grenadeMovementPrefab.SetFireVelocityFor(mouseToShootPositionDelta);
    Vector2 projectileFireVelocity = grenadeMovementPrefab.GetFireVelocity();
    projectileDirection = projectileFireVelocity.normalized;
    
    aimCursorManager.GrenadeCursor.SetPositionFor(
      grenadeMovementPrefab,
      shootAnchorPosition,
      mouseToShootPositionDelta
    );
    if (aimPreview) {
      aimPreview.SetPreview(grenadeMovementPrefab, shootAnchorPosition, mouseToShootPositionDelta);
    }
  }

  private Quaternion GetWeaponRotation(Vector2 direction) {
    Quaternion targetRotation = Quaternion.LookRotation(transform.forward, direction) * Quaternion.Euler(0, 0, 90);
    Quaternion weaponRotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    return weaponRotation;
  }

  private bool IsInDeadzone(Vector2 position) {
    return aimDeadzone.OverlapPoint(position);
  }
}
