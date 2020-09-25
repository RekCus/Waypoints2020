using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Opdrachten
{
    /// <summary>
    /// De path follower class is verantwoordelijk voor de beweging.
    /// Deze class zorgt ervoor dat het object (in Tower Defense) vaak een enemy, het path afloopt
    /// tip: je kunt de transform.LookAt() functie gebruiken en vooruitbewegen.
    /// </summary>
    public class PathFollower : MonoBehaviour
    {
        private float _arrivalThreshold = 0.5f;

        [SerializeField]
        private float speed = 2.5f;

        public int index = 0;

        public GameObject body;

        private Transform Target;

        public Path path;
        private void Start()
        {
            Target = path.waypoints[0].transform;
        }
        private void Update()
        {
  
            if (Target != null)
            {

                if (Vector3.Distance(transform.position, Target.position) <= _arrivalThreshold)
                {
                    index++;
                    if (index == path.waypoints.Length)
                    {
                        Target = null;
                    }
                    else
                    {
                        Target = path.GetNextWaypoint(index).transform;
                    }
                }
                else
                {
                    body.transform.LookAt(Target);
                    transform.position = Vector3.MoveTowards(transform.position,Target.position,speed/100);
                }
            }
        }

    }
}