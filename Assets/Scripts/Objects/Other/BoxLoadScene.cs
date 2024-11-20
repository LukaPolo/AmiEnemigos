using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxLoadScene : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CatKey cat = other.GetComponent<CatKey>();
            if (cat.HasKey)
            {
                SceneManager.LoadScene("VictoryLv2");
            }            
        }
    }
}
