using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.View
{
    /// <summary>
    /// G�re les boutons du menu ppal
    /// </summary>
    public class MainMenuView : MonoBehaviour
    {
        #region Propri�t�s

        /// <summary>
        /// L'image du bouton de son
        /// </summary>
        [field: SerializeField]
        public Image SoundImg
        {
            get;
            set;
        }

        /// <summary>
        /// L'image du bouton de la musique
        /// </summary>
        [field: SerializeField]
        public Image MusicImg
        {
            get;
            set;
        }

        /// <summary>
        /// L'ic�ne du son activ�
        /// </summary>
        [field: SerializeField]
        public Sprite SoundOnIcon
        {
            get;
            set;
        }

        /// <summary>
        /// L'ic�ne du son d�sactiv�
        /// </summary>
        [field: SerializeField]
        public Sprite SoundOffIcon
        {
            get;
            set;
        }

        /// <summary>
        /// L'ic�ne de la musique activ��
        /// </summary>
        [field: SerializeField]
        public Sprite MusicOnIcon
        {
            get;
            set;
        }

        /// <summary>
        /// L'ic�ne de la musique d�sactiv�e
        /// </summary>
        [field: SerializeField]
        public Sprite MusicOffIcon
        {
            get;
            set;
        }

        #endregion

        #region Fonctions publiques

        /// <summary>
        /// Lance une nouvelle session
        /// </summary>
        public void StartGameBtn()
        {
            SceneManager.LoadSceneAsync(1);
        }

        /// <summary>
        /// Ferme le jeu
        /// </summary>
        public void QuitBtn()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }

        /// <summary>
        /// Coupe ou remet le son
        /// </summary>
        public void MuteSoundBtn()
        {
            int sound = PlayerPrefs.GetInt("sound", 1);

            sound = sound == 1 ? 0 : 1;
            SoundImg.sprite = sound == 1 ? SoundOnIcon : SoundOffIcon;
            FindObjectOfType<AudioListener>().enabled = sound == 1;

            PlayerPrefs.SetInt("sound", sound);
        }

        /// <summary>
        /// Coupe ou remet la musique
        /// </summary>
        public void MuteMusicBtn()
        {
            int music = PlayerPrefs.GetInt("music", 1);

            music = music == 1 ? 0 : 1;
            MusicImg.sprite = music == 1 ? MusicOnIcon : MusicOffIcon;

            PlayerPrefs.SetInt("music", music);
        }

#endregion
    }
}