using UnityEngine;
using Mirror;
namespace SpaceBattle.Server
{
    public class ServerLogic : NetworkBehaviour
    {
        [Tooltip("How long to wait before returning to room scene. can be used to show a message meanwhile.")]
        public float timeToWaitWhenEndOfGame = 2.5f;

        private bool isGameWon;
        private int minNumOfPlayers;

        public override void OnStartServer()
        {
            base.OnStartServer();
            isGameWon = false;
        }

        private void Update()
        {
            int numOfPlayers = NetworkManager.singleton.numPlayers;
            //if there is less then minPlayers(=2) players left, then there is one player left.
            //show him a message and quit.
            minNumOfPlayers = GameObject.FindObjectOfType<NetworkRoomManager>().minPlayers;
            if (numOfPlayers <= minNumOfPlayers - 1 && !isGameWon)
            {
                Debug.Log("Only one player left");
                isGameWon = true;
                showMessageToPlayer();
                Invoke("restartServer", timeToWaitWhenEndOfGame);
            }

        }

        private void showMessageToPlayer()
        {
            Debug.Log("Searching for last player");
            GameObject lastPlayer = GameObject.FindGameObjectWithTag("Player");
            if (!lastPlayer)
            {
                Debug.Log("Didn't find the last player");
            }
            Debug.Log("found last player");
            //todo: add here
            lastPlayer.GetComponent<showMessages>().TargetShowWinMessage();
            Debug.Log("called the show mossage method");
        }

        private void restartServer()
        {
            //stop the host. makes him go to the offline scene which sends him straight to the server listening mode
            //from ServerInit component:
            NetworkManager.singleton.StopHost();
        }
    }
}
