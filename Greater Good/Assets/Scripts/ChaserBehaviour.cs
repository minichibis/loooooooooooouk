using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehaviour : MonoBehaviour
{
    List<MonsterPathing> previousNodes;

    private int maxPossibleNodes = 12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Vector3> PathToTravel()
    {
        List<Vector3> navigationalNodes = new List<Vector3>();

        for (int i = 0; i <= previousNodes.Count; i++)
        {
            navigationalNodes.Add(previousNodes[i].transform.position);
        }

        return navigationalNodes;
    }
}
