using UnityEngine;
using System.Collections;

public class MicInput : MonoBehaviour {
	
	private bool initialized = false;
	//Script MicrophoneInput
    void Start(){
		
	}
    void Update(){
    	if (!initialized) {
			if (Microphone.devices.Length > 0) {
				string device = Microphone.devices[0];
	    		audio.clip = Microphone.Start(device, true, 999, 44100);
	    		//while (!(Microphone.GetPosition(device) > 0))
	    		//{}
				audio.Play();
				initialized = true;
				Debug.Log("Initialized");
			}
			Debug.Log("Devices: " + Microphone.devices.Length);
		}

		else {
	        //if (!gameObject.activeSelf) return;
	        float[] data = new float[735];
	        audio.GetOutputData(data, 0);
		    //take the median of the recorded samples
	        ArrayList s = new ArrayList();
	        foreach (float f in data)
	        {
	            s.Add(Mathf.Abs(f));
	        }
	        s.Sort();
	        //Volume = (float)s[735 / 2];
	    }
	}
}
