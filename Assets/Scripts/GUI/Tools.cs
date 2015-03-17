using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour {

    // For the UI
    public void LoadScene(string scene) {
        Application.LoadLevel(scene);
    }

    public void ToggleActive(GameObject obj) {
        obj.SetActive(!obj.activeSelf);
    }
}
