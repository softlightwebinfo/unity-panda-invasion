using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Waypoint firstWaypoint;
    // Variable booleana para saber si el raton se halla sobre una zona donde poder poner torretas
    private bool _isPointerOnAllAllowedArea = false;
    private Transform spwanPoint;
    private HealthBarScript playerHealth;
    private int numberOfEnemiesToDefeat;

    [Header("Configuración de pantallas")]
    public GameObject winningScreen;
    public GameObject losingScreen;

    [Header("Enemigos y oleadas")]
    public GameObject enemyPrefab;
    public int numberOfWaves; // Numero de oleadas
    public int numberOfEnemyPerWave;// Numero de enemigos por oleada
    public static SugarMeterScript sugarMeter;

    private void Start()
    {
        if (!sugarMeter)
        {
            sugarMeter = FindObjectOfType<SugarMeterScript>();
        }

        this.playerHealth = FindObjectOfType<HealthBarScript>();
        this.spwanPoint = GameObject.Find("SpawingPoint").transform;
        StartCoroutine(WavesSpawner());
    }

    public bool isPointerOnAllAllowedArea()
    {
        return _isPointerOnAllAllowedArea;
    }

    // Se llama cuando el raton entra dentro de alguno de los colliders
    private void OnMouseEnter()
    {
        _isPointerOnAllAllowedArea = true;
    }

    // Se llama cuando el raton sale del collider
    private void OnMouseExit()
    {
        _isPointerOnAllAllowedArea = false;
    }


    ////////////////////
    //// GAME OVER /////
    ////////////////////


    // Metodo para ser llamado cuando se cunplan las condiciones
    private void GameOver(bool playerHasWon)
    {
        if (playerHasWon)
        {
            this.winningScreen.SetActive(true);
        }
        else
        {
            this.losingScreen.SetActive(true);
        }
        // Congelamos el tiempo para que se pare el videojuego detras de las escenas.
        Time.timeScale = 0;
    }

    // Funcion que lamamos cada vez que matamos a un enemigo
    public void OnMoreEnemyInHell()
    {
        this.numberOfEnemiesToDefeat--;
        sugarMeter.AddSugar(5);
    }

    // Funcion que daña la vida del jugador cuando el panda alcanza la tarta
    // Monitorizara ademas si todavia queda vida y si no se nos agoto,
    // llamara al game over con el parametro has hanado a FALSE
    public void BiteTheCake(int damage)
    {
        bool isCakeAllEaten = this.playerHealth.ApplyDamage(damage);
        Debug.Log(isCakeAllEaten);
        if (isCakeAllEaten)
        {
            this.GameOver(false);
        }

        // Como hay un panda menos, lo notificamos al Game Manager
        this.OnMoreEnemyInHell();
    }

    // Corutina que creara olleadas de enemigos
    private IEnumerator WavesSpawner()
    {
        // Para cada oleada
        for (int i = 0; i < numberOfWaves; i++)
        {
            // LLamamos a la rutina de panda spawner para que gestione la oleada en question
            // Y esperamos a que esta haya concluido
            yield return EnemySpawner();
            // Cuando la corutina acaba, puedo incrementar el numero de enemigos para la siguiente olleada
            this.numberOfEnemyPerWave += 3;
        }
        GameOver(true);
    }

    // Corutina que crea los enemigos de una olelada simple y espera hasta que no queda ninguno
    private IEnumerator EnemySpawner()
    {
        // Tengo que derrotar a tantos panda como indique la olleada actual
        numberOfEnemiesToDefeat = numberOfEnemyPerWave;
        // Vamos a generar progresivamente los enemigos de lla oleada
        for (int i = 0; i < numberOfEnemyPerWave; i++)
        {
            // Instanciamos al enemigo, en la posicion del spawner y sin rotar nada
            Instantiate(this.enemyPrefab, this.spwanPoint.position, Quaternion.identity);
            // Ponemos la corutina a descansar unos segundos aleatorios, que dependera de cuantos enemigos haya que instanciar
            float ratio = (i * 1.0f) / (numberOfEnemyPerWave - 1);
            float timeToWait = Mathf.Lerp(3.0f, 5.0f, ratio) + Random.Range(0f, 2.0f);
            yield return new WaitForSeconds(timeToWait);
        }
        // Una vez que todos los enemigos se han spawneados, esperar a que todos hayan sido derrotados por el jugador
        // o bien este no pueda derrotarlos, y muera...
        yield return new WaitUntil(() => numberOfEnemiesToDefeat <= 0);
    }
}
