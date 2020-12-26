using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeIn;

    private readonly string gitHubURL = "https://github.com/Toscan0";
    private readonly string linkedinURL = "https://www.linkedin.com/in/tiago-henriques-638252132/";

    public void PlayButton()
    {
        fadeIn.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void GitHubButton()
    {
        Application.OpenURL(gitHubURL);
    }

    public void LinkedinButton()
    {
        Application.OpenURL(linkedinURL);
    }

    
}
