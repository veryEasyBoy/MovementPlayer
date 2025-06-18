using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


internal class StartGame : MonoBehaviour
{
    public static bool IsMobile;
    public static bool IsPK;
    [SerializeField] private GameObject[] deactiveObject;
    private void Awake()
    {
        CheckingPlatform();
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
        Indicators.canBloodSpell = 0;
    }

    private IEnumerator LoadGamme()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
    public void CheckingPlatform()
    {
        if (Screen.dpi > 120)
        {
            Debug.Log(Screen.width);
            Debug.Log(Screen.currentResolution);
            Debug.Log(Screen.dpi);
            IsMobile = true;
            IsPK = false;
            Application.targetFrameRate = 500;
            Debug.Log("Mobile");
        }
        else
        {
            for(int i = 0; i < deactiveObject.Length; i++)
            {
                 deactiveObject[i].SetActive(false);
            }
            Debug.Log(Screen.width);
            Debug.Log(Screen.currentResolution);
            Debug.Log("PK");
            IsMobile = false;
            IsPK = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
