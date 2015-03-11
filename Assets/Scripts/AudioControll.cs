using UnityEngine;
using System.Collections;

public class AudioControll : MonoBehaviour {
	
	private bool muteEffects = false;
	private bool muteBackground = false;

	private GameObject gameController;

	public AudioClip transformSound;
	public AudioClip attacksound;
	public AudioClip enemyDeath;

	void Start(){
		gameController = GameObject.FindGameObjectWithTag ("GameController");
	}

	public void MuteToggle(string MuteType){
		if(MuteType == "Effects"){
			switch(muteEffects){
				case true:
					muteEffects = false;
					break;
				default:
					muteEffects = true;
					break;
			}
		}else if(MuteType == "Background"){
			switch(muteBackground){
			case true:
				muteBackground = false;
				gameController.GetComponent<AudioSource>().volume = 1;
				break;
			default:
				muteBackground = true;
				gameController.GetComponent<AudioSource>().volume = 0;
				break;
			}
		}
	}

	public void PlayAudio(AudioClip Audio, float Volume = 1){
		if (!muteEffects) {
			GetComponent<AudioSource>().clip = Audio;
			GetComponent<AudioSource>().volume = Volume;
			GetComponent<AudioSource>().Play();
		}
	}
}
