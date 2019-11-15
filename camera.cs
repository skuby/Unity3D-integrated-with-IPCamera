using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	
	public string uri = "rtsp://192.168.1.10/media/video1";
	public string username;
	public string password;
	
	
	Texture2D cam;
	
	
	public void Start() {
		cam=new Texture2D(5, 1, TextureFormat.RGB24, false);
		StartCoroutine(Fetch());
	}
	
	
	public IEnumerator Fetch() {
		while(true) {
			Debug.Log("fetching... "+Time.realtimeSinceStartup);
			
			WWWForm form = new WWWForm();
			form.AddField("dummy", "field");    // required by WWWForm
			WWW www = new WWW(uri, form.data, new System.Collections.Generic.Dictionary<string,string>() {  // using www.headers is depreciated by some odd reason
				{"Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(username+":"+password))}
			});
			yield return www;
			
			if(!string.IsNullOrEmpty(www.error))
				throw new UnityException(www.error);
			
			www.LoadImageIntoTexture(cam);
		}
	}
	
	
	public void OnGUI() {
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), cam);
	}
	
}