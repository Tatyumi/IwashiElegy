using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherStartPanelController : MonoBehaviour
{
    /// <summary>全てのゲームオブジェクト</summary>
    public GameObject[] AllGameObjects;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void Initialize()
    {
        // 全てのゲームオブジェクトを非表示にする
        WaveDirector.GameObjectsSwtichActive(AllGameObjects, false);
    }
}
