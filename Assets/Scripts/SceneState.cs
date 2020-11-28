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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateState()
    {
        artifacts = GameObject.Find("Player").GetComponent<Status>().artifacts;
    }
}
