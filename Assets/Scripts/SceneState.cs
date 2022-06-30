using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState : MonoBehaviour
{
    public int artifacts;

    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
    }

    public void UpdateState()
    {
        artifacts = Player.Instance.Artifacts;
    }
}
