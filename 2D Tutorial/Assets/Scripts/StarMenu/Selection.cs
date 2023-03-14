using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPossition;


    private void Update()
    {
        // change option menu die
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);
        // choose options
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.F))
            Interact();
}
private void Awake()
{
    rect = GetComponent<RectTransform>();
}
private void ChangePosition(int _change)
{
    currentPossition += _change;

    if (currentPossition < 0)
        currentPossition = options.Length - 1;
    else if (currentPossition > options.Length - 1)
        currentPossition = 0;

    rect.position = new Vector3(rect.position.x, options[currentPossition].position.y, 0);
}
private void Interact()
{
     
    options[currentPossition].GetComponent<Button>().onClick.Invoke();
}
}
