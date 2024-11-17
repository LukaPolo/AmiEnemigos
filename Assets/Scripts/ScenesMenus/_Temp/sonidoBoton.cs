using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sonidoBoton : MonoBehaviour {
   public AudioSource sound;
   public AudioClip soundMenu;
   public AudioSource music;
   public AudioClip musicMenu;
   
 public void SoundButton()//Esta funcion es llamada desde el Boton a traves del componente Event Trigger.
    {
        //Simplemente eliges que sonido sonara (en el caso que tengas mas clip)
        sound.clip = soundMenu;
        //Lo desactivo y activo para que genere el sonido
        
        sound.enabled = false;
        sound.enabled = true;
    }
  public void MusicButtomOff()
  {
      music.clip = musicMenu;
      music.enabled = false;
  }
  public void MusicButtomOn ()
  {
      music.clip = musicMenu;
      music.enabled = true;
  }
  public void UpdateMusicVolumNeg ()
  {
      music.volume -= 1;
      //sound.volume -= 1;
  }
  public void UpdateMusicVolumPos ()
  {
      music.volume += 1;
      //sound.volume += 1;
  }

}
