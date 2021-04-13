using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Tile))]
public class TileSpriteController : MonoBehaviour
{
    #region Member Variables

    public Sprite WallSprite;
    public Sprite FloorSprite;

    #endregion

    // Use this for initialization
    void Start()
    {
        SetTileSprite();
    }

    #region Public Methods

    public void ResetSpriteController()
    {
        SetTileSprite();
    }

    #endregion

    #region Private Methods

    private void SetTileSprite()
    {
        ////////////////////////////////////////
        //Local Variables

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        Tile tileController;

        ////////////////////////////////////////

        tileController = GetComponent<Tile>();

        if (tileController.Blocked == true)
        {
            renderer.sprite = WallSprite;
        }

        else
        {
            renderer.sprite = FloorSprite;
        }
    }

    #endregion
}
