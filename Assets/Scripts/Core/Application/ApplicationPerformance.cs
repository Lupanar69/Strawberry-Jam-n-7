using System;
using UnityEngine;

/// <summary>
/// G�re le framerate et le GC en cas de m�moire faible
/// </summary>
public class ApplicationPerformance
{
    #region Fonctions publiques

    /// <summary>
    /// Appel�e au lancement du jeu
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    public static void BeforeSplashScreen()
    {
        SetFPS(45);
        Application.lowMemory += OnLowMemory;
    }

    /// <summary>
    /// Assigne un nombre fixe de FPS pour �viter
    /// de consommer trop d'�nergie
    /// </summary>
    /// <param name="fps">Le nombre de FPS auquel bloquer le jeu</param>
    public static void SetFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }

    #endregion

    #region Fonctions priv�es

    /// <summary>
    /// Appel�e quand la m�moire restante est faible
    /// </summary>
    private static void OnLowMemory()
    {
        GC.Collect();
        Resources.UnloadUnusedAssets();
    }


    #endregion
}
