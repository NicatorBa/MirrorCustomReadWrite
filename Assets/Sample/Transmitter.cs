using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Sample;
using UnityEngine;

public class Transmitter : NetworkBehaviour
{
    public override void OnStartServer()
    {
        base.OnStartServer();

        StartCoroutine(SendIds());
    }

    private IEnumerator SendIds()
    {
        var i = 0;
        while (i < 10)
        {
            RpcReceiveId(IdData.Parse(Guid.NewGuid().ToString()));
            i++;

            yield return new WaitForSeconds(10);
        }
    }

    [ClientRpc]
    private void RpcReceiveId(IdData data)
    {
        Debug.Log(data);
    }
}