using UnityEngine;
using System.Collections;

/// <summary>
/// This will use a Raycast to get a GAmeObject via the mouse position.
/// </summary>
public static class GetGameObjectViaMouse
{
    public static GameObject Start()
    {
        //////////////////////////////////////////////////////////
        //Local Variables

        RaycastHit hitInfo = new RaycastHit();

        bool hit = false;

        //////////////////////////////////////////////////////////

        hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

        if (hit == true)
        {
            return hitInfo.transform.gameObject;
        }

        else
        {
            return null;
        }
    }
}
