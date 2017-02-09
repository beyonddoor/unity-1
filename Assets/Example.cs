﻿using UnityEngine;
using System.Collections;
using PubNubAPI;
using System.Collections.Generic;

public class Example : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log ("Starting");
        PNConfiguration pnConfiguration = new PNConfiguration ();
        pnConfiguration.SetSecure = true;
        Debug.Log ("PNConfiguration");
        PubNub pubnub = new PubNub (pnConfiguration);
        Debug.Log ("PubNub");
        List<string> listChannelGroups = new List<string> (){"channelGroup1", "channelGroup2"};
        List<string> listChannels = new List<string> (){"channel1", "channel2"};
        //pubnub.Subscribe ().SetChannelGroups (listChannelGroups).SetChannels(listChannels).Execute();
        Debug.Log ("before Time");
        pubnub.Time ().Async (new PNTimeCallback<PNTimeResult>(){
            /*OnResponse = (PNTimeResult result, PNStatus status) =>
            {
                
            }*/
            //Debug.Log ("in Time")
        });
        //pubnub.Time ().Async (new PNCallback<PNTimeResult>(){

            //Debug.Log ("in Time")
        //});

        Debug.Log ("after Time");
        //pubnub.Subscribe ().Async<string> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
