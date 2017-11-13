using UnityEngine;
using System.Collections;

public class PlayVideoOnLoad : MonoBehaviour {
	#if !UNITY_ANDROID
    public MovieTexture _movie;
	#endif


	// Use this for initialization
	void Start () {
		#if UNITY_ANDROID
		string moviePath = this.GetComponent<MeshRenderer>().materials[0].name;

		Handheld.PlayFullScreenMovie(moviePath);

		#else
		_movie.loop = true;
		_movie.Play();

		#endif


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
