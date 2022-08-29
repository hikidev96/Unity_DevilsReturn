using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class RelicController : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Required"), Required] GameObject mainObj;
        [SerializeField, TitleGroup("Required"), Required] private Transform relicsParent;
        [SerializeField, TitleGroup("Detail")] private List<RelicData> startingRelics;

        private void Start()
        {
            EquipStartingRelic();
        }

        public void EquipRelic(Relic relic)
        {
            Debug.Log($"Relic Equipped : {relic.RelicData.RelicName.GetString()}");

            if (FindRelic(relic) != null)
            {
                relic.Behaviour.Renew();
            }
            else
            {
                relic.transform.parent = relicsParent;
                relic.transform.localPosition = Vector3.zero;

                relic.Behaviour.SetMainObj(mainObj);
                relic.Behaviour.Activate();
            }            
        }

        private void EquipStartingRelic()
        {
            for (int i = 0; i < startingRelics.Count; ++i)
            {
                var relic = Instantiate(startingRelics[i].Prefab).GetComponent<Relic>();

                EquipRelic(relic);
            }
        }

        private Relic FindRelic(Relic relic)
        {
            for (int i = 0; i < relicsParent.childCount; ++i)
            {
                var relicThatAlreadyOnControlling = relicsParent.GetChild(i).GetComponent<Relic>();
                if (relicThatAlreadyOnControlling.RelicData.RelicName.GetString() == relic.RelicData.RelicName.GetString())
                {
                    return relicsParent.GetChild(i).GetComponent<Relic>();
                }
            }

            return null;
        }
    }
}