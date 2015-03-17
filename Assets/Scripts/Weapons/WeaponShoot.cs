using UnityEngine;
using UnityEngine.UI;
using System.Collections;

    // Boy Voesten

public class WeaponShoot : MonoBehaviour {

    public GameObject bullet1;
    public GameObject bulletSpawn;
    public AudioClip startReloadSound;
    public AudioClip finishReloadSound;
    public AudioClip shootSound;
    public Text txtAmmo;
    protected bool paused = false;
    private float nextFireTime;
    private float ammo;
    private float reloadTime = 1.5f;
    private float counter;
    private bool reloading = false;
    private PlayerData playerData;
    private float _fireRate;
    private float _maxAmmo;

	void Awake () {
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
        ApplyUpgrades();
        ammo = _maxAmmo;
        UpdateUI();

    }
	
	void Update () {
        if (paused) return;

        KeyInputs();

        if (reloading) {
            counter -= Time.deltaTime;
            if (counter <= 0) {
                GetComponent<AudioSource>().clip = finishReloadSound;
                GetComponent<AudioSource>().Play();
                ammo = _maxAmmo;
                reloading = false;
                UpdateUI();
            }
        }
	}

    void KeyInputs() {
        // Mouse Click 1 & is able to fire:
        if (Input.GetMouseButton(0) && Time.time > nextFireTime) {
            if (ammo > 0) {
                SchootBullet();
            } else if (ammo <= 0 && !reloading) {
                Reload();
            }
        // Buttom R & is able to reload:
        } else if (Input.GetKeyDown(KeyCode.R) && !reloading && ammo < _maxAmmo) {
            Reload();
        }
    }

    void SchootBullet() {
        ammo--;
        nextFireTime = Time.time + _fireRate;
        Instantiate(bullet1, bulletSpawn.transform.position, transform.rotation);
        GetComponent<AudioSource>().clip = shootSound;
        GetComponent<AudioSource>().Play();
        UpdateUI();
    }

    void Reload() {
        ammo = 0;
        GetComponent<AudioSource>().clip = startReloadSound;
        GetComponent<AudioSource>().Play();
        reloading = true;
        counter = reloadTime;
        UpdateUI();
    }

    void GamePause() {  // This function will run when the player presses esc, because of the GamePause.cs
        paused = (!paused) ? true : false;

        // The only possible way to have upgraded one of these is by having opened the pause menu.
        ApplyUpgrades();
        UpdateUI();
    }

    public void ApplyUpgrades() {
        // Fire Rate
        switch (playerData.fireRateLvl) {
            case 0:
                _fireRate = 0.2f;
                break;
            case 1:
                _fireRate = 0.15f;
                break;
            case 2:
                _fireRate = 0.1f;
                break;
            case 3:
                _fireRate = 0.75f;
                break;
            default:
                _fireRate = 0.75f;
                break;
        }
        // Max Ammo for the weapon
        switch (playerData.ammoLvl) {
            case 0:
                _maxAmmo = 5;
                break;
            case 1:
                _maxAmmo = 8;
                break;
            case 2:
                _maxAmmo = 12;
                break;
            case 3:
                _maxAmmo = 15;
                break;
            default:
                _maxAmmo = 15;
                break;
        }
    }
    
    public void UpdateUI() {
        txtAmmo.text = "Ammo: " + ammo + " / " + _maxAmmo;
    }
}
