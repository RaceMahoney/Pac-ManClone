using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDelay : MonoBehaviour {

    public int p;

    //TODO increase pause time
    private void Start()
    {
        StartCoroutine(Pause(p));
    }

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 1;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
    }

}
