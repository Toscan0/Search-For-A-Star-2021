using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [SerializeField]
    private LoadSceneManager loadSceneManager;

    public void LoadNextScene()
    {
        loadSceneManager.LoadNextScene();
    }
}
