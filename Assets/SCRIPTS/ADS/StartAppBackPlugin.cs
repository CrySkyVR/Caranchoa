using UnityEngine;
using System.Collections;
using StartApp;

public class StartAppBackPlugin : MonoBehaviour{

	void Update () {
	#if UNITY_ANDROID
		if (Input.GetKeyUp (KeyCode.Escape)) {
			if (StartAppWrapper.onBackPressed(gameObject.name) == false) {
                Application.Quit();
            }
		}
	#endif
    }
}