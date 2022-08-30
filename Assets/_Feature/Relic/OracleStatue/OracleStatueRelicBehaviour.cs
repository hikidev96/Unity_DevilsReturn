using System.Threading.Tasks;

namespace DevilsReturn
{
    public class OracleStatueRelicBehaviour : RelicBehaviour
    {
        private float restoreValue = 1.0f;

        public override void Activate()
        {
            base.Activate();

            restoreValue = 1.0f;
            StartRestoreHP();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Renew()
        {
            base.Renew();

            restoreValue += 1.0f;
        }

        private async void StartRestoreHP()
        {
            while (true)
            {   
                await Task.Delay(5000);

                if (mainObj == null)
                {
                    break;
                }

                mainObj.GetComponentInChildren<HealthPoint>().Restore(restoreValue);
            }
        }
    }
}