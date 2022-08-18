using System.Collections.Generic;
using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/ScriptableObjectSet")]
    public class ScriptableObjectSet : ScriptableObject
    {
        [SerializeField] List<ScriptableObject> scriptableObjects;

        public ScriptableObject Get()
        {
            if (scriptableObjects == null)
            {
                return null;
            }

            var result = scriptableObjects[Random.Range(0, scriptableObjects.Count)];

            return result;
        }
    }
}