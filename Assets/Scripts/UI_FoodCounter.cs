using UnityEngine;
using UnityEngine.UI;

public class UI_FoodCounter : MonoBehaviour
{
    private Text text;
    private int count;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void IncreaseCounter()
    {
        count++;
        text.text = "Food: " + count.ToString("000");
    }
}
