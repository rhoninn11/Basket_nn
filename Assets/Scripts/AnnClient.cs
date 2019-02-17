using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AnnClient : MonoBehaviour
{
    public int port;
    public string pokeMessage;

    public async Task<string> ServerCommand(string inputData)
    {
        ClientWebSocket ws = new ClientWebSocket();
        CancellationToken ct = new CancellationToken();

        ArraySegment<byte> dataBuffer = new ArraySegment<byte>(Encoding.ASCII.GetBytes(inputData));


        try
        {
            await ws.ConnectAsync(new Uri($"ws://localhost:{port}"), ct);
        }
        catch (Exception e)
        {
            Debug.Log("connection problem");
            return null;
        }

        await ws.SendAsync(dataBuffer, WebSocketMessageType.Text, true, ct);

        WebSocketReceiveResult result;
        StringBuilder resposeBuilder = new StringBuilder();
        ArraySegment<byte> responeBuffer = new ArraySegment<byte>(new byte[128]);

        do
        {
            result = await ws.ReceiveAsync(responeBuffer, ct);
            string responseChunk = Encoding.ASCII.GetString(responeBuffer.Array, 0, result.Count);
            resposeBuilder.Append(responseChunk);

        } while (!result.EndOfMessage);

        // Debug.Log(resposeBuilder.ToString());
        return resposeBuilder.ToString();
    }

    

    
}
