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

        private List<Relic> controllingRelics = new List<Relic>();

        public List<Relic> ControllingRelics => controllingRelics;

        private void Start()
        {
            EquipStartingRelic();
        }

        private void OnDisable()
        {
            for (int i = 0; i < controllingRelics.Count; ++i)
            {
                controllingRelics[i].Behaviour.Deactivate();
            }
        }

        public void EquipRelic(Relic relic)
        {
            var findedRelic = FindRelic(relic);

            if (findedRelic != null)
            {
                findedRelic.Behaviour.Renew();
                Destroy(relic.gameObject);
            }
            else
            {
                relic.transform.parent = relicsParent;
                relic.transform.localPosition = Vector3.zero;

                relic.Behaviour.SetMainObj(mainObj);
                relic.Behaviour.Activate();

                controllingRelics.Add(relic);
            }
        }

        public void EquipRelic(RelicData relicData)
        {
            EquipRelic(Instantiate(relicData.Prefab).GetComponent<Relic>());
        }

        private void EquipStartingRelic()
        {
            for (int i = 0; i < startingRelics.Count; ++i)
            {
                var relic = Instantiate(startingRelics[i].Prefab).GetComponent<Relic>();
                relic.EquipTo(this);                              
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