using UnityEngine;
using System.Collections;
using UnityEngine.UI;

    // Boy Voesten

public class PlayerData : MonoBehaviour {

    public Text txtSP;
    public Text txtKills;
    public Text txtLvl;
    public Text txtXP;

    private float   _xp             = 0.0f;
    private float   _lvlUpXP        = 1000.0f;
    private uint    _lvl            = 1;
    private uint    _kills          = 0;
    private int     _Skillpoints    = 0;

    private uint    _fireRateLvl    = 0;
    private uint    _ammoLvl        = 0;
    private uint    _damageLvl      = 0;

    void Start() {
        txtSP.text = "Skillpoints: " + _Skillpoints;
        txtKills.text = "Kills: " + _kills;
        txtLvl.text = "Lvl: " + _lvl;
        txtXP.text = "XP: " + _xp;
    }

    // Level Up
    private void LevelUp() {
        GetComponent<AudioSource>().Play();
        _lvl += 1;
        _lvlUpXP += Mathf.Floor((500 + (_lvlUpXP / 4)));
        txtLvl.text = "Lvl: " + _lvl;
        IncreaseSP(1);
    }

    // Experience Points
    public void IncreaseXP(uint points) {
        _xp += points;
        if (_xp >= _lvlUpXP) {
            _xp -= _lvlUpXP;
            LevelUp();
        }
        txtXP.text = "XP: " + _xp;
    }

    // Skill Points
    public void IncreaseSP(int points) {
        _Skillpoints += points;
        txtSP.text = "Skillpoints: " + _Skillpoints;
    }

    // Kill Count
    public void IncreaseKills(uint amount) {
        _kills += amount;
        txtKills.text = "Kills: " + _kills;
    }

    // Fire Rate
    public void IncreaseFR(uint lvl) {
        _fireRateLvl += lvl;
    }

    // Max Ammo
    public void IncreaseAmmo(uint lvl) {
        _ammoLvl += lvl;
    }

    // Damage
    public void IncreaseDMG(uint lvl) {
        _damageLvl += lvl;
    }


    // GETTERS & SETTERS

    public float lvlUpXP {
        get {
            return _lvlUpXP;
        }
    }

    public float xp {
        get {
            return _xp;
        }
    }
    
    public int skillpoints {
        get {
            return _Skillpoints;
        }
    }

    public uint fireRateLvl {
        get {
            return _fireRateLvl;
        }
    }
    
    public uint ammoLvl {
        get {
            return _ammoLvl;
        }
    }

    public uint damageLvl {
        get {
            return _damageLvl;
        }
    }

    

}
