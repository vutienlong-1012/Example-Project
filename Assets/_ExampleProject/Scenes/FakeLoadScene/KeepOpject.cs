using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VTLTools;

public class KeepOpject : Singleton<KeepOpject>
{
    public GameObject fpsText;
    public GameObject ingameDebug;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);

        fpsText.SetActive(UserDataManager.IsShowFps);
        ingameDebug.SetActive(UserDataManager.IsShowDebug);

    }
}
