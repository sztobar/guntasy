using Kite;
using UnityEngine;

public class GunAimHandler : BaseWeaponAimHandler {

  [SerializeField]
  private CircleCollider2D aimDeadzone;

  [SerializeField]
  private WeaponDirection3Handler weaponDirection3Handler;

  [SerializeField]
  private float focusedAimScale = 1f;

  [SerializeField]
  private Transform shootAnchor;

  [SerializeField]
  private RotationFixMode rotationFixMode = RotationFixMode.ArmLookWithBulletRotationFix;

  [SerializeField]
  private float rotationSpeed;

  private Vector2 mouseToWeaponDelta;
  private CursorManager cursorManager;
  private PlayerCameraConfiner playerCamera;
  private PlayerDodgeComponent playerDodge;
  private IWeaponAnimator weaponAnimator;
  private IWeaponRecoil weaponRecoil;
  private Vector2 lastMousePositionToDeadzone = Vector2.zero;

  public override Vector2 MousePosition => mouseToWeaponDelta + (Vector2)transform.position;

  public override void Inject(IWeaponDI di) {
    weaponAnimator = di.WeaponAnimator;
    playerCamera = di.PlayerDI.Camera;
    playerDodge = di.PlayerDI.GameplayController.Dodge;
    weaponDirection3Handler.Inject(di);
    weaponRecoil = di.WeaponRecoil;
  }

  private void Start() {
    cursorManager = CursorManager.Instance;
  }

  public override bool LookAt(Vector2 newMousePosition) {
    if (IsInDeadzone(newMousePosition)) {
      if (lastMousePositionToDeadzone == Vector2.zero) {
        Vector2 deadzoneToMouseDirection = (newMousePosition - (Vector2)aimDeadzone.transform.position).normalized;
        lastMousePositionToDeadzone = deadzoneToMouseDirection * aimDeadzone.radius;
        mouseToWeaponDelta = lastMousePositionToDeadzone + (Vector2)aimDeadzone.transform.position - (Vector2)transform.position;
        return true;
      }
      cursorManager.SetWorldPosition((Vector2)aimDeadzone.transform.position + lastMousePositionToDeadzone);
      return false;
    } else {
      cursorManager.SetWorldPosition(newMousePosition);
      lastMousePositionToDeadzone = newMousePosition - (Vector2)aimDeadzone.transform.position;
      mouseToWeaponDelta = newMousePosition - (Vector2)transform.position;
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
      transform.rotation = GetWeaponRotation();
      weaponDirection3Handler.SetDirection(Vector2Extensions.QuaternionToVector2(transform.rotation));
    }
  }

  private Quaternion GetWeaponRotation() {
    Vector2 mousePosition = MousePosition;
    Quaternion armRotation = GetRotationInPosition(mousePosition, shootAnchor.position);
    Quaternion weaponRotation = Quaternion.Slerp(transform.rotation, armRotation, Time.deltaTime * rotationSpeed);
    Quaternion recoilValue = weaponRecoil.Recoil;
    return weaponRotation * recoilValue;
  }

  private bool IsInDeadzone(Vector2 position) {
    return aimDeadzone.OverlapPoint(position);
  }

  public override Quaternion GetFireRotation() {
    Vector2 mousePosition = MousePosition;
    Quaternion projectileRotation = transform.rotation;
    if (!aimDeadzone.OverlapPoint(mousePosition)) {
      projectileRotation = GetRotationInPosition(mousePosition, shootAnchor.position);
    }
    return projectileRotation;
  }

  public override void FocusAim(bool focus) {
    if (focus) {
      playerCamera.SetConfinerScale(focusedAimScale);
    } else {
      playerCamera.ResetConfinerScale();
    }
  }

  private Quaternion GetRotationInPosition(Vector2 mousePosition, Vector2 shootPosition) {
    Vector2 directionVector = mousePosition - shootPosition;
    Quaternion rotation = Quaternion.LookRotation(transform.forward, directionVector) * Quaternion.Euler(0, 0, 90);
    return rotation;
  }

  public override Direction3 GetDirection3() {
    return weaponDirection3Handler.GetDirection3();
  }

  enum RotationFixMode {
    WeaponLookWithRotationSpeed,
    WeaponLookWithRotationSpeedAndInstaReload,
    ArmLookWithBulletRotationFix,
    ArmLook,
    WeaponLook,
  }
}
