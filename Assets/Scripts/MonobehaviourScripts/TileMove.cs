using UnityEngine;
using System.Collections;

public class TileMove : MonoBehaviour
{
    #region Member Variables

    public float MoveTime = 1.0f;

    public bool TraceDebugMove = false;

    private BoxCollider BoxCollider;

    private bool EnableMove = false;

    private Vector3 MovePosition;

    private PlayerActions ActionController;

    #endregion

    #region Monobehaviour Methods

    public void Start()
    {
        BoxCollider = GetComponent<BoxCollider>();

        ActionController = GetComponent<PlayerActions>();
    }

    public void Update()
    {
        SmoothMovement();
    }

    #endregion

    #region Public Methods

    public void SetTransform(int x, int y)
    {
        ////////////////////////////////////////
        //Local Variables

        Vector3 newPosition = new Vector3(x, y, 0);

        ////////////////////////////////////////

        transform.position = newPosition;
    }

    public void SetTransform(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public GameObject TryMove(Vector3 newPosition)
    {
        //////////////////////////////////////
        //Local Variables

        RaycastHit hit;

        //////////////////////////////////////

        BoxCollider.enabled = false;
        Physics.Linecast(transform.position, newPosition, out hit);
        Debug.DrawLine(transform.position, newPosition, Color.red, 10.0f);
        BoxCollider.enabled = true;

        if  ( (hit.transform != null) && (TraceDebugMove == true) )
        {
            StaticTrace.Log(string.Format("Object name:  {0}", hit.collider.gameObject.name));
            StaticTrace.Log(string.Format("Blocked:  {0}", hit.collider.gameObject.GetComponent<Tile>().Blocked.ToString()));
        }

        if ((hit.transform == null) || (hit.collider.gameObject.GetComponent<Tile>().Blocked == false))
        {
            EnableMove = true;
            MovePosition = newPosition;
            return null;
        }

        else
        {
            return hit.collider.gameObject;
        }
    }

    #endregion

    #region Private Methods

    private void SmoothMovement()
    {
        if (EnableMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, MovePosition, Time.deltaTime * MoveTime);

            if (transform.position == MovePosition)
            {
                EnableMove = false;

                transform.position = MovePosition;

                if (GetComponent<Tile>().Type == TileType.TILE_PLAYER)
                {
                    ActionController.ActionPerformed();
                }
            }
        }
    }

    #endregion
}
