using UnityEngine;

public class ReelTest : MonoBehaviour
{
    [SerializeField] private ReelController reel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            reel.Spin();
        }
    }
}