using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectionBehaviour : MonoBehaviour
{
    [SerializeField] private Tile selectedTile;


    private void Update()
    {
        var hit = Physics2D.Raycast(Input.mousePosition, Vector2.down);

        if (hit)
            selectedTile = hit.transform.GetComponent<Tile>();

        selectedTile.gameObject.SetActive(false);
    }
}
