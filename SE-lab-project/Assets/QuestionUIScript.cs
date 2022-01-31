using System.Collections;
using System.Collections.Generic;
using Gamekit3D;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuestionUIScript : MonoBehaviour
{
    public bool alwaysDisplayMouse;

    public GameObject QuestionUICanvas;
    public GameObject Question2UICanvas;
    public GameObject Question3UICanvas;
    public GameObject Question4UICanvas;
    public GameObject Question5UICanvas;
    public GameObject Question6UICanvas;
    public GameObject Question7UICanvas;
    public GameObject Question8UICanvas;
    public GameObject Question9UICanvas;
    public GameObject Question10UICanvas;
    public GameObject Question11UICanvas;
    public GameObject Question12UICanvas;
    public GameObject Question13UICanvas;
    public GameObject Question14UICanvas;
    public GameObject Question15UICanvas;
    public GameObject Question16UICanvas;
    public GameObject Question17UICanvas;
    public GameObject Question18UICanvas;
    public GameObject Question19UICanvas;
    public GameObject Question20UICanvas;
    public GameObject Question21UICanvas;
    public GameObject Question22UICanvas;
    public GameObject Question23UICanvas;
    public GameObject Question24UICanvas;
    public GameObject Question25UICanvas;

    public GameObject CorrectCanvas;
    public GameObject WrongCanvas;
    public GameObject ScoreBoardCanvas;
    TextMeshProUGUI text;
    public int score = 0;
    public int question_count = 0;
    public int wrong = 0;
    //public GameObject Damageable;
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
            //Debug.Log(rnd);
            a = (int)(rnd*100);
            //Debug.Log(a);
            a = a%25;
            //Debug.Log(a);
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
            score++;
            question_count++;
            m_InPause = true;
            SwitchPauseState();
            Debug.Log("Correct ans. found");
            Debug.Log("Score: " + score);
            GameObject Child = ScoreBoardCanvas.transform.GetChild(1).gameObject;
            GameObject GrandChild = Child.transform.GetChild(0).gameObject;
            text = GrandChild.GetComponent<TextMeshProUGUI>();
            text.text = "Correct : "+score+"\tWrong  : "+wrong+"\tTotal     : 17";
            StartCoroutine(Text());
        }

        IEnumerator Text()  //  <-  its a standalone method
        {
            CorrectCanvas.SetActive(true);
            yield return new WaitForSeconds(3);
            CorrectCanvas.SetActive(false);
        }

        public void wrongAnswer(){
            question_count++;
            wrong++;
            m_InPause = true;
            SwitchPauseState();
            //Debug.Log("Wrong ans. found");
            //Debug.Log("Score: " + score);
            GameObject Child = ScoreBoardCanvas.transform.GetChild(1).gameObject;
            GameObject GrandChild = Child.transform.GetChild(0).gameObject;
            text = GrandChild.GetComponent<TextMeshProUGUI>();
            text.text = "Correct : "+score+"\tWrong  : "+wrong+"\tTotal     : 17";
            //OnReceiveDamage.Invoke();
            //Ellen.GetComponent<Damageable>().ApplyDamage(d);
            StartCoroutine(Text1());
        }

        IEnumerator Text1()  //  <-  its a standalone method
        {
            WrongCanvas.SetActive(true);
            yield return new WaitForSeconds(3);
            WrongCanvas.SetActive(false);
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

        if(a==0)
        {
            if (QuestionUICanvas)
                QuestionUICanvas.SetActive(!m_InPause);
        }
        else if(a==1){
            if (Question2UICanvas)
                Question2UICanvas.SetActive(!m_InPause);
        }
        else if(a==2){
            if (Question3UICanvas)
                Question3UICanvas.SetActive(!m_InPause);
        }
        else if(a==3){
            if (Question4UICanvas)
                Question4UICanvas.SetActive(!m_InPause);
        }
        else if(a==4){
            if (Question5UICanvas)
                Question5UICanvas.SetActive(!m_InPause);
        }
        else if(a==5){
            if (Question6UICanvas)
                Question6UICanvas.SetActive(!m_InPause);
        }
        else if(a==6){
            if (Question7UICanvas)
                Question7UICanvas.SetActive(!m_InPause);
        }
        else if(a==7){
            if (Question8UICanvas)
                Question8UICanvas.SetActive(!m_InPause);
        }
        else if(a==8){
            if (Question10UICanvas)
                Question10UICanvas.SetActive(!m_InPause);
        }
        else if(a==9){
            if (Question11UICanvas)
                Question11UICanvas.SetActive(!m_InPause);
        }
        else if(a==10){
            if (Question12UICanvas)
                Question12UICanvas.SetActive(!m_InPause);
        }
        else if(a==11){
            if (Question13UICanvas)
                Question13UICanvas.SetActive(!m_InPause);
        }
        else if(a==12){
            if (Question14UICanvas)
                Question14UICanvas.SetActive(!m_InPause);
        }
        else if(a==13){
            if (Question15UICanvas)
                Question15UICanvas.SetActive(!m_InPause);
        }
        else if(a==14){
            if (Question16UICanvas)
                Question16UICanvas.SetActive(!m_InPause);
        }
        else if(a==15){
            if (Question17UICanvas)
                Question17UICanvas.SetActive(!m_InPause);
        }
        else if(a==16){
            if (Question18UICanvas)
                Question18UICanvas.SetActive(!m_InPause);
        }
        else if(a==17){
            if (Question19UICanvas)
                Question19UICanvas.SetActive(!m_InPause);
        }
        else if(a==18){
            if (Question20UICanvas)
                Question20UICanvas.SetActive(!m_InPause);
        }
        else if(a==19){
            if (Question21UICanvas)
                Question21UICanvas.SetActive(!m_InPause);
        }
        else if(a==20){
            if (Question22UICanvas)
                Question22UICanvas.SetActive(!m_InPause);
        }
        else if(a==21){
            if (Question23UICanvas)
                Question23UICanvas.SetActive(!m_InPause);
        }
        else if(a==22){
            if (Question24UICanvas)
                Question24UICanvas.SetActive(!m_InPause);
        }
        else if(a==23){
            if (Question25UICanvas)
                Question25UICanvas.SetActive(!m_InPause);
        }
        else if(a==24){
            if (Question3UICanvas)
                Question3UICanvas.SetActive(!m_InPause);
        }
        else if(a==25){
            if (Question9UICanvas)
                Question9UICanvas.SetActive(!m_InPause);
        }

        m_InPause = !m_InPause;
    }
}
