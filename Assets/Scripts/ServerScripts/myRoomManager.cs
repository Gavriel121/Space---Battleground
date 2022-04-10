using Mirror;

namespace SpaceBattle.Server
{
    public class myRoomManager : NetworkRoomManager
    {
        public override void OnApplicationQuit()
        {
            base.OnApplicationQuit();
        }

        public override void OnRoomStopHost()
        {
            base.OnRoomStopHost();
        }

        public override void OnServerReady(NetworkConnection conn)
        {
            base.OnServerReady(conn);
        }

        public override void OnStopServer()
        {
            base.OnStopServer();
        }
    }
}
