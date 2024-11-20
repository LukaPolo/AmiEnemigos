using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private string scene;
    public void PlayFade()
    {
        anim.Play("FadeOut");
        StartCoroutine(Temporizador());
    }

    private IEnumerator Temporizador()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(scene);
    }
}
