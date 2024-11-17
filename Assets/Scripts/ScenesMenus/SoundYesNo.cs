using UnityEngine;

public class SoundYesNo : MonoBehaviour
{
    // Método para activar el audio
    public void EnableSound()
    {
        AudioListener.pause = false; // Reactivar el audio en la escena.
    }

    // Método para desactivar el audio
    public void DisableSound()
    {
        AudioListener.pause = true; // Silenciar todo el audio en la escena.
    }
}
