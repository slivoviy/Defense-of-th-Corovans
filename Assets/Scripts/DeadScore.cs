using TMPro;
using UnityEngine;

public class DeadScore : MonoBehaviour {
    [SerializeField] private GameManager gm;
    [SerializeField] private TextMeshProUGUI text;
    void Start() {
        text.text = text.text + " " + gm.score;
    }

}
