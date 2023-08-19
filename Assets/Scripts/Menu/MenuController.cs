using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController MenuControllerInstance;
    GameObject panel;
    RectTransform myRectTransform;


    /*COntrol de las pausas*/
    public bool isPaused;


    /*Para mostrar UI de objetos*/
    public UI_ForObjects UI_forObjects;

    /*Control de Menues*/
    public GameObject menuInGame;
    public GameObject menuNormal;

    /*Control de firsPerson*/
    public FirstPersonMovement movimientoPlayer;
    public FirstPersonLook camaraPlayer;
    public bool canPause;

    //public FirstPersonMovement movimientoPlayer;
    //public FirstPersonLook camaraPlayer;
    //public bool canPause;

    /*Pantall de GameOver*/
    public GameObject gameOverScreen_;

    /*Pantalla de fin*/
    public GameObject finalScreen_;

    public bool activarMenuInicial;
    public bool activarMenuInGame;

    private void Awake()
    {
        if (MenuControllerInstance == null)
        {
            MenuControllerInstance = this;
            //DontDestroyOnLoad(this.gameObject);
            //LoadSceneEvent.eventsBeforeSceneChange += preserveThroughScenes;
            //LoadSceneEvent.eventsAfterSceneChange += startMenuController;
        }
        //else
        //{
        //    Destroy(this.gameObject);
        //}
    }


    void Start()
    {
        startMenuController();//ESTO ES UNA FUNCION QUE SE LLAMA EN CADA CAMBIO DE ESCNEA Y DESACTIVA LOS MENUES

        //activamos el menu de start al inicio del juego

        if(activarMenuInicial) 
        {
            menuNormal.gameObject.gameObject.SetActive(true);
        }
        else{
            menuNormal.gameObject.gameObject.SetActive(false);
        }
        if (activarMenuInGame)
        {
            menuInGame.gameObject.gameObject.SetActive(true);
        }
        else
        {
            menuInGame.gameObject.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || OVRInput.GetDown(OVRInput.RawButton.Start)) //HASTA ACABAR EL OBSERVE DE LOS OTROS
        {
            if (isPaused)
            {
                hideMenu();
            }
            else 
            {
                showMenu();
            }

            isPaused = !isPaused;
        }
    }


    public void showMenu()
    {
        menuInGame.gameObject.SetActive(true);
        CanvasManager.instance.PutObjetInFrontOfPlayer(this.gameObject);
    }

    public void hideMenu()
    {
        menuInGame.gameObject.SetActive(false);
    }


    public void goToLobby() 
    {
        GameManager.GameManagerInstance.loadScene(0, true);
        menuNormal.gameObject.gameObject.SetActive(true);
    }
    public void BotonInicioMenu() 
    {
        GameManager.GameManagerInstance.loadNextScene();
    }


    public void ChangeScene(int index)
    {
        GameManager.GameManagerInstance.loadScene(index, false);
    }

    public void BotonInicioMenu_SinCanvasManager()
    {
        GameManager.GameManagerInstance.loadScene(SceneManager.GetActiveScene().buildIndex + 1, false);
    }

    public void BotonSalirMenu()
    {
        GameManager.GameManagerInstance.exitSimulator();
    }
    public void BotonRestartMenu() 
    {
        GameManager.GameManagerInstance.restarScene();
    }

    public void showGameOverScreen() 
    {
        gameOverScreen_.gameObject.SetActive(true);

        this.camaraPlayer.sensitivity = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void showFinalScreen()
    {
        finalScreen_.gameObject.SetActive(true);

        this.camaraPlayer.sensitivity = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        this.movimientoPlayer.enabled = false;
    }
    //public void PausarYDespausar() 
    //{
    //    if (isPaused)
    //    {
    //        this.camaraPlayer.sensitivity = 2;
    //        Cursor.visible = false;
    //        Cursor.lockState = CursorLockMode.Locked;
    //    }
    //    else 
    //    {
    //        this.camaraPlayer.sensitivity = 0;
    //        Cursor.visible = true;
    //        Cursor.lockState = CursorLockMode.None;
    //    }

    //    this.movimientoPlayer.enabled = isPaused;
    //    isPaused = !isPaused;
    //    menuInGame.SetActive(isPaused);
    //}



    void startMenuController() 
    {
        myRectTransform = GetComponent<RectTransform>();
        //panel = GameObject.FindGameObjectWithTag("Panel");
        if (CanvasManager.instance != null)
        {
            this.transform.SetParent(CanvasManager.instance.gameObject.transform);
            myRectTransform.localPosition = new Vector2(0, 0);
            myRectTransform.sizeDelta = new Vector2(0, 0);
            myRectTransform.localScale = new Vector2(1, 1);
        }

        /*DESACTIVAMOS LOS MENUS*/
        menuInGame.gameObject.SetActive(false);
        menuNormal.gameObject.SetActive(false);

        /*PARA TENER REFERENCIAS A LA HORA DE PAUSAR EL JUEGO*/
        //movimientoPlayer = GameObject.FindObjectOfType<FirstPersonMovement>();
        //camaraPlayer = GameObject.FindObjectOfType<FirstPersonLook>();
        //if (movimientoPlayer != null && camaraPlayer != null) 
        //{
        //    canPause = true;
        //}

    }
    //public void preserveThroughScenes()
    //{
    //    isPaused = false;
    //    this.transform.SetParent(GameManager.GameManagerInstance.gameObject.transform); 
    //}
}
