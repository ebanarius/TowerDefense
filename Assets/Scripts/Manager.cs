using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Loader<Manager>
{
    //Глобальные переменные
    #region 
    [SerializeField] // Для сохранения значений в дебаге юнити (таб справа)
    GameObject spawnPoint;
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    int maxEnemiesOnScreen;
    [SerializeField]
    int TotalEnemiesOnLevel;
    [SerializeField]
    int enemiesDelaySpawn;
    const float spawnDelay = 0.5f; // 0.5 sec delay
    int enemiesOnScreen = 0; // Для каждого лвл свое значение (для начала 0 противников на экране)
    #endregion

    //Главные методы
    #region Методы
    void Start() // Вызывается перед обновлением первого кадра
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if (enemiesDelaySpawn > 0 && enemiesOnScreen < TotalEnemiesOnLevel)
        {
            for (int i = 0; i < enemiesDelaySpawn; i++)
            {
                if (enemiesOnScreen < maxEnemiesOnScreen)
                {
                    GameObject newEnemy = Instantiate(enemies[1] as GameObject);
                    newEnemy.transform.position = spawnPoint.transform.position;
                    enemiesOnScreen++;
                }
            }
            yield return new WaitForSeconds(spawnDelay); //Задержка перед респавном противником
            StartCoroutine(Spawn());
        }
    }

    public void removeEnemyFromScreen()
    {
        if (enemiesOnScreen > 0) enemiesOnScreen--;
    }

    #endregion
}
