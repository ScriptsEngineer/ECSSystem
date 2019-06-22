using UnityEngine;

namespace Classic
{
    public class Movement : MonoBehaviour
    {

        private void Update()
        {
            Vector3 pos = transform.position;
            pos += transform.forward * GameManager.instance.enemySpeed * Time.deltaTime;

            if (pos.z < GameManager.instance.bottomBound)
                pos.z = GameManager.instance.topBound;

            transform.position = pos;
        }

    }
}

