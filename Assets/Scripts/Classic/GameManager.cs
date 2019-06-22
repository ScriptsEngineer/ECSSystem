using UnityEngine;


namespace Classic
{
    public class GameManager : GameManagerAsbtract
    {

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            CheckInput();
        }

        protected override void AddShips(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject obj = InstantiateShip();
            }

            InsertAmount(amount);
        }

    }
}
