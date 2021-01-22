using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TowerManager : Loader<TowerManager>
{

    TowerBtn towerBtnPressed;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Клик мышью
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);

            //Определенные точки place tower
            if (hit.collider.tag == "TowerSide")
            {
                hit.collider.tag = "TowerSideFull";
                placeTower(hit);
            }
             //[1]Здесь если только тянуть
        }
        //[1]Всегда отображать картинку при нажатии на бтн
        if (spriteRenderer.enabled) FollowMouse();
    }

    #region Основные функции

    //Расположение башни
    public void placeTower(RaycastHit2D hit)
    {
        //Если можно расположить башню
        //Чтобы башня не ставилась сразу после клика на кнопку

        //Если не навили на одну из кнопок а также towerBtnPressed != null
        if (!EventSystem.current.IsPointerOverGameObject() )
        {
            GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
            DisableDrag();
        }

    }

    public void SelectedTower(TowerBtn towerSelected)
    {
        towerBtnPressed = towerSelected;
        EnableDrag(towerBtnPressed.DragSprite);
        Debug.Log("Была нажата (Башня) № " + towerBtnPressed.gameObject);
    }


    #region Фантомная башня за мышью
    public void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    public void EnableDrag(Sprite sprite)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
    }

    public void DisableDrag()
    {
        spriteRenderer.enabled = false;
    }
    #endregion
    #endregion
}
