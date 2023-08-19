using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneEvent
{
    public static System.Action eventsBeforeSceneChange;
    public static System.Action eventsAfterSceneChange;

    /*public static System.Action<string, string, string> eventoMuerteString;//eventoConparametros*/
}
public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;
    public SoundManager soundManagerInstance;
    public int frames;

    //Control los menus
    public int EscenaParaActivarMenuGame;


    //Controlar secuencia de niveles
    public int secuenciaNiveles;//si es 0 es pirque deberia estar en el primer nivel, pero si no estamos es porque estamos testeando una escena aislada
    public LoadingScreenObject loadingPrefab;

    //Control GAME OVER
    public bool simulationEnd;

    private void Awake()
    {
        if (GameManagerInstance == null)
        {
            Application.targetFrameRate = frames;
            GameManagerInstance = this;
            DontDestroyOnLoad(GameManagerInstance);
            soundManagerInstance = this.GetComponent<SoundManager>();
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    public void loadNextScene()
    {
        //difuminado
        secuenciaNiveles++;
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void loadScene(int index, bool conAnimation) 
    {
        if (conAnimation) 
        {
            StartCoroutine(LoadScene(index));
        }
        else 
        {
            StartCoroutine(LoadSceneWithoutAnimation(index));
        }

        if (index == 0) 
        {
            secuenciaNiveles = 0;
        }
    }

    IEnumerator LoadScene(int indexScene)
    {
        LoadingScreenObject loadingPrefab_TMP = Instantiate(loadingPrefab);
        CanvasManager.instance.showCanvas(loadingPrefab_TMP.gameObject);

        yield return new WaitForSeconds(0.5f);
        LoadSceneEvent.eventsBeforeSceneChange?.Invoke();
        AsyncOperation op = SceneManager.LoadSceneAsync(indexScene);

        while (!op.isDone)
        {
            yield return null;
        }
        LoadSceneEvent.eventsAfterSceneChange?.Invoke();

    }

    IEnumerator LoadSceneWithoutAnimation(int indexScene)
    {
        yield return new WaitForSeconds(0.5f);
        LoadSceneEvent.eventsBeforeSceneChange?.Invoke();
        AsyncOperation op = SceneManager.LoadSceneAsync(indexScene);

        while (!op.isDone)
        {
            yield return null;
        }
        LoadSceneEvent.eventsAfterSceneChange?.Invoke();

    }


    //public void loadScene2(int index)
    //{
    //    secuenciaNiveles++;
    //    StartCoroutine(LoadScene2(index));
    //    if (index == 0)
    //    {
    //        secuenciaNiveles = 0;
    //    }
    //}
    //IEnumerator LoadScene2(int indexScene)
    //{
    //    LoadSceneEvent.eventsBeforeSceneChange?.Invoke();
    //    AsyncOperation op = SceneManager.LoadSceneAsync(indexScene);

    //    while (!op.isDone)
    //    {
    //        yield return null;
    //    }
    //    LoadSceneEvent.eventsAfterSceneChange?.Invoke();

    //}

    /*public async void LoadScene2(int indexScene) 
    {
        Instantiate(prefabLoadingScreen);

        LoadSceneEvent.eventsBeforeSceneChange?.Invoke();
        AsyncOperation op = SceneManager.LoadSceneAsync(indexScene);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            await Task.Delay(100);
            prefabLoadingScreen.loadingPorcentage = op.progress;
            yield return null;
        }
        await Task.Delay(1000);
        LoadSceneEvent.eventsAfterSceneChange?.Invoke();
        op.allowSceneActivation = true;
    }*/


    public void exitSimulator() 
    {
        Application.Quit();
    }

    public void restarScene() 
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
}
