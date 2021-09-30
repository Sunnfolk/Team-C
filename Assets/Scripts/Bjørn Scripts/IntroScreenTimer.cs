using System.Collections;
using UnityEngine;

public class IntroScreenTimer : MonoBehaviour
{
    public float waitTime = 4f;

    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        
        SceneController.LoadScene("MainScene");
    }
}
