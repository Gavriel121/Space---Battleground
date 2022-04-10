using UnityEngine;
using Mirror;

namespace SpaceBattle.Server
{
    public class ServerInit : NetworkBehaviour
    {
        public static ServerInit singleton;

        private void Awake()
        {
            singleton = this;
        }

        //always start the server automaticly:
        private void Start()
        {
            if (Application.isBatchMode)
            {
                NetworkRoomManager.singleton.StartServer();
            }
        }
    }
}
