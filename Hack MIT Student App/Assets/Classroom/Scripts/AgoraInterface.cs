using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using agora_gaming_rtc;

public class AgoraInterface : MonoBehaviour
{
    private static string appId = "fb1642d0fbed4481b839fdeefd687cbc";
    public IRtcEngine mRtcEngine;
    public uint mRemotePeer;

    public void loadEngine(){

        if(mRtcEngine != null){
            Debug.Log("Engine already exists, please unload it");
            return;
        }

        mRtcEngine = IRtcEngine.GetEngine(appId);
        mRtcEngine.SetLogFilter(LOG_FILTER.DEBUG);
        Debug.Log("initializing engine: "+mRtcEngine);
    }

    public void joinChannel(string channelName){
        Debug.Log("Joining channel:" + channelName);

        if(mRtcEngine == null){
            Debug.Log("Engine needs to be initialzed before joining a channel");
            return;
        }
        //callbacks
        mRtcEngine.OnJoinChannelSuccess = OnJoinChannelSuccess;
        mRtcEngine.OnUserJoined = OnUserJoined;
        mRtcEngine.OnUserOffline = OnUserOffline;
        
        //functionality
       mRtcEngine.EnableVideo();
       mRtcEngine.EnableVideoObserver();
        mRtcEngine.JoinChannel("Karin", null, 0);
        Debug.Log(mRtcEngine);
    }
    public string getSdkVersion(){
        return IRtcEngine.GetSdkVersion();

    }
    public void leaveChannel(){
        Debug.Log("leaving channel");

        if(mRtcEngine == null){
            Debug.Log("Engine needs to be initialized before leaving a channel");
            return;
        }
        mRtcEngine.LeaveChannel();
        mRtcEngine.DisableVideoObserver();

    }
    public void unloadEngine(){
        Debug.Log("Unloading Agora Engine");
        if(mRtcEngine != null){
            IRtcEngine.Destroy();
            mRtcEngine = null;
        }
    }
    void OnJoinChannelSuccess (string channel, uint uid, int elapsed){
        Debug.Log("ONJOINCHANNELSUCCESS Succesfully joined channel:" + channel+" uid: "+uid);
    }    

    void OnUserJoined(uint uid, int elapsed){
        Debug.Log("UIDUIDUIDUIDUIDUIDUIDUIDUIUDIUDIUDIDUIDUIDUIDUIDUIDUIDUIDUIDUIDUIDUIDUIDU: " +uid);

        //remote stream to scene

        //create game object
        GameObject go;
        go = GameObject.CreatePrimitive(PrimitiveType.Plane);

        go.name = uid.ToString();

        //configure video surface
        VideoSurface o = go.AddComponent<VideoSurface>();
        o.SetForUser(uid);
        //o.mAdjustTransform += OnTransformDelegate;
        o.SetEnable(true);
        //timestamp if it breaks: 26:00

        mRemotePeer = uid;
    }

    void OnUserOffline(uint uid, USER_OFFLINE_REASON reason){
        Debug.Log("user has left the channel");

        //remove the game object from scene
        GameObject go = GameObject.Find(uid.ToString());
        if(!ReferenceEquals(go, null)){
            Destroy(go);
        }

    }

    // private void OnTransformDelegate(uint uid, string objName, ref Transform transform){
    //     if(uid ==0){
    //         transform
    //     }
    // timestampe: 28:59
    // }
}
