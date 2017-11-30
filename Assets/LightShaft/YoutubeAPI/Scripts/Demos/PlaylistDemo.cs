using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaylistDemo : MonoBehaviour {
    YoutubeAPIManager youtubeapi;

    public Text searchField;
    public YoutubeVideoUi[] videoListUI;
    public GameObject videoUIResult;
    public GameObject mainUI;
    public string PlaylistID;

    void Start()
    {
        //Get the api component
        youtubeapi = GameObject.FindObjectOfType<YoutubeAPIManager>();
        if (youtubeapi == null)
        {
            youtubeapi = gameObject.AddComponent<YoutubeAPIManager>();
        }

        GetPlaylist();
    }

    public void GetPlaylist()
    {
       youtubeapi.GetPlaylistItems(PlaylistID, 10, OnGetPlaylistDone);
    }

    void OnGetPlaylistDone(YoutubePlaylistItems[] results)
    {
		videoUIResult.SetActive(true);
        LoadVideosOnUI(results);

    }

    void LoadVideosOnUI(YoutubePlaylistItems[] videoList)
    {
        for (int x = 0; x < videoList.Length; x++)
        {
            videoListUI[x].GetComponent<YoutubeVideoUi>().videoName.text = videoList[x].snippet.title;
            videoListUI[x].GetComponent<YoutubeVideoUi>().videoId = videoList[x].videoId;
            videoListUI[x].GetComponent<YoutubeVideoUi>().thumbUrl = videoList[x].snippet.thumbnails.defaultThumbnail.url;
            videoListUI[x].GetComponent<YoutubeVideoUi>().LoadThumbnail();
        }
    }
}
