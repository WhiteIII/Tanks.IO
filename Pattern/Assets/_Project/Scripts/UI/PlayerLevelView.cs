using TMPro;
using UnityEngine;

public class PlayerLevelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    public void Draw(string number) =>
        _text.text = number;
}
