using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDataSetter : MonoBehaviour
{
    [Header("Player Settings")]
    public Text Position;
    public InputField Force;

    [SerializeField] GameObject Player;

    //[Header("Naural Network Settings")]

    private void Update()
    {
        SetPlayerData();
    }

    private void SetPlayerData()
    {
        var posX = Player.transform.localPosition.x;
        var posY = Player.transform.localPosition.y;
        var posZ = Player.transform.localPosition.z;
        Position.text = $"Position: X: {posX:00.00}, Y: {posY:00.00}, Z: {posZ:00.00}";
    }
}
