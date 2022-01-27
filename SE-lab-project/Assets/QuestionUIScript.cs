using System.Collections;
using System.Collections.Generic;
using Gamekit3D;
using UnityEngine;
using UnityEngine.Playables;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuestionUIScript : MonoBehaviour
{
    public bool alwaysDisplayMouse;
    public GameObject QuestionUICanvas;
    public GameObject Question2UICanvas;
    //public GameObject optionsCanvas;
    //public GameObject controlsCanvas;
    //public GameObject audioCanvas;

    public float rnd;
    public int a;
    protected bool m_InPause;
    protected PlayableDirector[] m_Directors;
    protected bool check = false;
    // Start is called before the first frame update
    public void SetUp()
    {
        if (!alwaysDisplayMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        m_Directors = FindObjectsOfType<PlayableDirector> ();
        check = true;
        if(check)
        {
            rnd = Random.value;
            Debug.Log(rnd);
            a = (int)(rnd*10);
            Debug.Log(a);
            a = a%2;
            Debug.Log(a);
            SwitchPauseState();
            check = false;
        }
    }

        public void ExitPause()
        {
            m_InPause = true;
            SwitchPauseState();
        }

        public void correctAnswer(){
            m_InPause = true;
            SwitchPauseState();
        }

        public void wrongAnswer(){
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
        }

        public void chooseA()
        {
            m_InPause = true;
            SwitchPauseState();
            //SceneController.RestartZone();
        }

        public void chooseB()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
        }

        public void chooseC()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
        }

        public void chooseD()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
        }


    protected void SwitchPauseState()
    {
        if (m_InPause && Time.timeScale > 0 || !m_InPause && ScreenFader.IsFading)
            return;

        if (!alwaysDisplayMouse)
        {
            Cursor.lockState = m_InPause ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !m_InPause;
        }

        for (int i = 0; i < m_Directors.Length; i++)
        {
            if (m_Directors[i].state == PlayState.Playing && !m_InPause)
            {
                m_Directors[i].Pause ();
            }
            else if(m_Directors[i].state == PlayState.Paused && m_InPause)
            {
                m_Directors[i].Resume ();
            }
        }
        
        if(!m_InPause)
            CameraShake.Stop ();

        if (m_InPause)
            PlayerInput.Instance.GainControl();
        else
            PlayerInput.Instance.ReleaseControl();

        Time.timeScale = m_InPause ? 1 : 0;

        if(a==1)
        {
            if (QuestionUICanvas)
                QuestionUICanvas.SetActive(!m_InPause);
        }
        else{
            if (Question2UICanvas)
                Question2UICanvas.SetActive(!m_InPause);
        }

        m_InPause = !m_InPause;
    }
}
