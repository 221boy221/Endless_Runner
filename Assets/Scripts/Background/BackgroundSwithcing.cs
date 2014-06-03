using UnityEngine;
using System.Collections;

public class BackgroundSwithcing : MonoBehaviour {

	public GameObject[] backgrounds;
	private int nrBackgrounds;
	private int currentBackground;

	// Use this for initialization
	void Awake () {
		nrBackgrounds = backgrounds.Length;
		currentBackground = nrBackgrounds + 1; //anders kiest hij de eerste niet
		chooseBackground ();
		changeBackgroundMusic();
	}

	public void chooseBackground(){
		int chosenBackground = Random.Range (0, nrBackgrounds);

		for (int i = 0; i < nrBackgrounds; i++) {
			if(chosenBackground == currentBackground){
				if(chosenBackground <= nrBackgrounds && chosenBackground != 0){
					chosenBackground -= 1;
				}else{
					chosenBackground += 1;
				}
			}
			if (i == chosenBackground) {
				backgrounds [i].gameObject.SetActive (true);
			} else {
				backgrounds [i].gameObject.SetActive (false);
			}
		}

		currentBackground = chosenBackground;
	}

	public void changeBackgroundMusic(){
		float randomPitch = Random.Range (0.95f, 1.1f);
		audio.pitch = randomPitch; 
	}
}
