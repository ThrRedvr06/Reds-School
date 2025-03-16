using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Events;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public sealed class StrictName : MonoBehaviourPunCallbacks
{
    public UnityEvent badNameEvent;

    private const string allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (targetPlayer.IsLocal && changedProps.ContainsKey("NickName"))
        {
            string name = (string)changedProps["NickName"];
            var charArray = name.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (!allowedCharacters.Contains(charArray[i]))
                {
                    badNameEvent.Invoke();
                    break;
                }
            }
        }        
    }
}
