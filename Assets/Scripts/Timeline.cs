using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Timeline: MonoBehaviour
{
    private PlayableDirector playableDirector;

    void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
        playableDirector.Play();
    }
}
