using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class CherryCounter : MonoBehaviour
{

    public static CherryCounter Instance;

    [SerializeField] public TMP_Text CherryText;
    public int currentCherry = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CherryText.text = "Cherry: " + currentCherry.ToString(); 
    }

    public void IncreaseCherry(int v)
    {
        currentCherry += v;
        CherryText.text = "Cherry: " + currentCherry.ToString();
    }
}
