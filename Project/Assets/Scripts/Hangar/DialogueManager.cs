using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private Text subtitles;
    //not show the dialogue every time we enter in hangar
    private static bool firstTime = false;

    private void Start()
    {
        subtitles.text = "";
        if (!firstTime)
        {
            firstTime = true;

            StartCoroutine(ManageDialogue());
        }
    }

    private IEnumerator ManageDialogue()
    {
        yield return new WaitForSeconds(0.2f);

        subtitles.text = "This is your hanagr.It's a safe place, you can rest here...";
        yield return new WaitForSeconds(2.5f);

        subtitles.text = "";
        yield return new WaitForSeconds(0.5f);

        subtitles.text = "But don't rest to much, there is a friend to find...";
        yield return new WaitForSeconds(2.5f);

        subtitles.text = "";
        yield return new WaitForSeconds(0.5f);

        subtitles.text = "You're gonna need a good aim for where you're going,";
        yield return new WaitForSeconds(2.5f);

        subtitles.text = "";
        yield return new WaitForSeconds(0.2f);

        subtitles.text = "Find the targets and practice.";
        yield return new WaitForSeconds(2.5f);

        subtitles.text = "When you're ready, look for a black hole to travel between worlds...";
        yield return new WaitForSeconds(2.5f);
        subtitles.text = "";
    }
}
