using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Mirror;

public class GetChat : NetworkBehaviour
{
    [SerializeField] private GameObject chatUI = null;
    [SerializeField] private TMP_Text chatTextOpen =null;
    [SerializeField] private TMP_Text chatTextClose =null;
    [SerializeField] private TMP_InputField inputField = null;

    private static event Action<string> onMessage;

    public override void OnStartAuthority() // pada saaat yang punya hak (client) spawn
    {
        chatUI.SetActive(true);
        onMessage += HandleNewMessage; // subcribe pesan yang di terima sekali pada diri sendiri
    }

    [ClientCallback] // agar server tidak ikut menerima
    private void OnDestroy()
    {
        if(!hasAuthority)
        {
            return;
        }
        onMessage -= HandleNewMessage; //unsubcribe pesan sehingga tidak menerima pesan
    }
    
    
    private void HandleNewMessage(string pesan)
    {
        chatTextOpen.text += pesan; // append pesan tetapi nanti akan di tambahi "\n" sebagai pemisah
        chatTextClose.text += pesan;
    }

    [Client] //client only
    public void kirim()
    {
        //if(!Input.GetKeyDown(KeyCode.Return)){return;}
        if(string.IsNullOrWhiteSpace(inputField.text))
        {
            return;
        }
        CmdSendMessage(inputField.text); // menyuruh server untuk mengirim text tersebut, fungsi dari passing command adalah agar tidak terjadi kesalahan input bila ada client lain yang mengisi namun bukan cliet yang bersangkutan
        inputField.text = string.Empty;

    }

    [Client] //client only
    public void kirimtombol()
    {
        if(!Input.GetKeyDown(KeyCode.Return)){return;}
        if(string.IsNullOrWhiteSpace(inputField.text))
        {
            return;
        }
        CmdSendMessage(inputField.text); // menyuruh server untuk mengirim text tersebut, fungsi dari passing command adalah agar tidak terjadi kesalahan input bila ada client lain yang mengisi namun bukan cliet yang bersangkutan
        inputField.text = string.Empty;

    }  

    [Command]// sebuah perintah yang perlu dijalankan oleh server atau host
    private void CmdSendMessage(string pesan)
    {
        RpcHandleMessage($"[{connectionToClient.connectionId}]:{pesan}"); // validasi pesan oleh server
    }

    [ClientRpc] // memanggil semua client 
    private void RpcHandleMessage(string pesan)
    {
        onMessage?.Invoke($"\n{pesan}");
    }

}
