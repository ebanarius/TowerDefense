using UnityEngine;

public class Enemy : MonoBehaviour
{

    #region переменные

    [SerializeField]
    Transform exit; // Взаимодействие с enemy
    [SerializeField]
    Transform[] wayPoints; // Контрольные точки пути
    [SerializeField]
    float navigation;

    Transform enemy;
    float navigationTime = 0; //Для обновления положения персонажей в пространстве
    int target = 0;

    #endregion

    void Start()
    {
        enemy = GetComponent<Transform>();
    }
    void Update()
    {
        if (wayPoints != null)
        {
            navigationTime += Time.deltaTime;
            if (navigationTime > navigation)
            {
                if (target < wayPoints.Length)
                    enemy.position = Vector3.MoveTowards(enemy.position, wayPoints[target].position, navigationTime); //Движение к след. точке по id
                
                else
                enemy.position = Vector3.MoveTowards(enemy.position, exit.position, navigationTime);
                navigationTime = 0;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (collision.tag == "MoveingPoint") target++;

        else if(collision.tag == "Finish")
            Manager.Instance.removeEnemyFromScreen();
            Destroy(gameObject);
    }
}
