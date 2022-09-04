using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pathfinding;

namespace DevilsReturn
{
    public class GroundController : BaseMonoBehaviour
    {
        [SerializeField] private AstarPath pathFinder;        
        [SerializeField] private List<Ground> grounds;
        [SerializeField]
        private List<Vector3> neighborPostions = new List<Vector3>()
        {
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(-150.0f, 0.0f, 0.0f),
            new Vector3(-150.0f, 0.0f, 150.0f),
            new Vector3(0.0f, 0.0f, 150.0f),
            new Vector3(150.0f, 0.0f, 150.0f),
            new Vector3(150.0f, 0.0f, 0.0f),
            new Vector3(150.0f, 0.0f, -150.0f),
            new Vector3(0.0f, 0.0f, -150.0f),
            new Vector3(-150.0f, 0.0f, -150.0f)
        };
        [SerializeField] private GameObject groundPrefab;

        private void OnEnable()
        {
            for (int i = 0; i < grounds.Count; ++i)
            {
                grounds[i].OnPlayerEnter.AddListener(RepositionGround);
            }
        }

        private void RepositionGround(Ground centerGround)
        {
            var missingPosition = new List<Vector3>();  
            var groundToReposition = new List<Ground>();

            for (int i = 0; i < grounds.Count; ++i)
            {
                grounds[i].isNeighborGround = false;
            }

            for (int i = 0; i < neighborPostions.Count; ++i)
            {
                var neighborGround = Physics.OverlapBox(centerGround.transform.position + neighborPostions[i], Vector3.one, Quaternion.identity, 1 << LayerMask.NameToLayer("Ground"));
                if (neighborGround.Length > 0)
                {
                    neighborGround[0].GetComponent<Ground>().isNeighborGround = true;
                }
                else
                {                    
                    missingPosition.Add(neighborPostions[i]);
                }
            }

            for (int i = 0; i < grounds.Count; ++i)
            {
                if (grounds[i].isNeighborGround == false)
                {
                    groundToReposition.Add(grounds[i]); 
                }
            }

            for (int i = 0; i < groundToReposition.Count; ++i)
            {
                groundToReposition[i].transform.position = centerGround.transform.position + missingPosition[i];
            }

            GridGraph gg = pathFinder.data.FindGraphOfType(typeof(GridGraph)) as GridGraph;
            gg.center = centerGround.transform.position;
            gg.Scan();
        }

        private void OnDrawGizmos()
        {
            var boxSize = new Vector3(150.0f, 10.0f, 150.0f);

            for (int i = 0; i < grounds.Count; ++i)
            {
                if (grounds[i].isNeighborGround == false)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(grounds[i].transform.position, boxSize);
                }
                else
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(grounds[i].transform.position, boxSize);
                }
            }
        }
    }
}