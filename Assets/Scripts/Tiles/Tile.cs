using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public int X { get; internal set; }
    public int Y { get; internal set; }

    private Color darkTileColor = new(0.05f, 0.05f, 0.05f, 1.0f);
    private Color lightTileColor = new(0.15f, 0.15f, 0.15f, 1.0f);
    private Color darkPathTileColor = new(0.8f, 0.8f, 0.3f, 1.0f);
    private Color lightPathTileColor = new(1.0f, 1.0f, 0.4f, 1.0f);

    public bool isGray, isWall, isTowerSpawned, isPath, isHovering;

    private Sprite wallSprite;
    private GameObject cursor;

    private void Start()
    {
        wallSprite = Resources.Load<Sprite>("Sprites/Wall");
        cursor = GameObject.Find("cursor_place_tower");

        if (isGray)
            GetComponent<SpriteRenderer>().color = darkTileColor;
        else
            GetComponent<SpriteRenderer>().color = lightTileColor;
    }

    private void Update()
    {
        if (isWall)
        {
            GetComponent<SpriteRenderer>().sprite = wallSprite;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            if (isGray && !isHovering)
                GetComponent<SpriteRenderer>().color = darkTileColor;
            else if (!isHovering)
                GetComponent<SpriteRenderer>().color = lightTileColor;
        }

        if (isPath)
        {
            if (isGray)
                GetComponent<SpriteRenderer>().color = darkPathTileColor;
            else
                GetComponent<SpriteRenderer>().color = lightPathTileColor;
        }
    }

    internal void SetPath(bool isPath)
    {
        this.isPath = isPath;

        if (isPath)
        {
            if (isGray)
                GetComponent<SpriteRenderer>().color = darkPathTileColor;
            else
                GetComponent<SpriteRenderer>().color = lightPathTileColor;
        }
        else
        {
            if (isGray)
                GetComponent<SpriteRenderer>().color = darkTileColor;
            else
                GetComponent<SpriteRenderer>().color = lightTileColor;
        }
    }

    private void Reset()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/default_tile");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTowerCursor();

        GameManager.Instance.TargetTile = this;

        cursor.transform.SetParent(TileManager.Instance.tiles[X, Y].transform);
        cursor.transform.position = new Vector2(X - Mathf.Ceil(LevelManager.MapWidth / 2), Y - Mathf.Ceil(LevelManager.MapHeight / 2));

        if (isWall) return;

        isHovering = true;
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;

        if (isWall) return;

        if (isGray)
            GetComponent<SpriteRenderer>().color = darkTileColor;
        else
            GetComponent<SpriteRenderer>().color = lightTileColor;

        ShowTowerCursor();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Reset();

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (isTowerSpawned)
            {
                isTowerSpawned = false;
                Tower.Destroy(GetComponentInChildren<Tower>(true));
            }

            if (isWall)
                isWall = false;

            ShowTowerCursor();
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (isPath) return;

            if (isWall && !isTowerSpawned)
            {
                var tower = Tower.Create<LaserTower>(transform);
                isTowerSpawned = true;
            }

            isWall = true;

            ShowTowerCursor();
        }
    }

    private void ShowTowerCursor()
    {
        if (isWall && !isTowerSpawned)
            cursor.SetActive(true);
        else
            cursor.SetActive(false);
    }
}
