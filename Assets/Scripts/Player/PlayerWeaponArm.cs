using UnityEngine;
using System.Collections;
using System;

public class PlayerWeaponArm : MonoBehaviour, IPlayerInjectable {

  [SerializeField]
  private ScriptableWeapon scriptableWeapon;

  [SerializeField]
  private BaseWeaponController weaponController;

  private PlayerDI playerDi;

  public BaseWeaponController Weapon => weaponController;

  public Action<BaseWeaponController> OnWeaponChange { get; set; }

  public void Inject(PlayerDI di) {
    playerDi = di;
    InitWeaponController();
  }

  private void InitWeaponController() {
    IWeaponDI weaponDI = weaponController.DI;
    weaponDI.PlayerDI = playerDi;
    weaponDI.Init();
    OnWeaponChange(weaponController);
  }

  public void SetScriptableWeapon(ScriptableWeapon newScriptableWeapon) {
    scriptableWeapon = newScriptableWeapon;
    Destroy(weaponController.gameObject);
    weaponController = Instantiate(scriptableWeapon.WeaponPrefab, transform);
    InitWeaponController();
  }

  public ScriptableWeapon GetScriptableWeapon() {
    return scriptableWeapon;
  }
}
