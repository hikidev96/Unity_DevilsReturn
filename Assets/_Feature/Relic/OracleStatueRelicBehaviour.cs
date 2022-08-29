using System.Threading.Tasks;

namespace DevilsReturn
{
    public class OracleStatueRelicBehaviour : RelicBehaviour
    {
        private float restoreValue = 1.0f;

        public override void Activate()
        {
            base.Activate();

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
                await Task.Delay(1000);
                mainObj.GetComponentInChildren<HealthPoint>().Restore(restoreValue);
            }
        }
    }
}
