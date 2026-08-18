using System.Collections;
using UnityEngine;

public class SlotMachineController : MonoBehaviour
{
    [Header("Reels")]
    [SerializeField] private ReelController reel1;
    [SerializeField] private ReelController reel2;
    [SerializeField] private ReelController reel3;

    [Header("Result")]
    [SerializeField] private SlotResultEvaluator resultEvaluator;

    public void SpinAll()
    {
        if (reel1.IsSpinning || reel2.IsSpinning || reel3.IsSpinning)
            return;

        StartCoroutine(SpinSequence());
    }

    private IEnumerator SpinSequence()
    {
        reel1.SetRandomResult();
        reel2.SetRandomResult();
        reel3.SetRandomResult();

        reel1.Spin();

        yield return new WaitForSeconds(0.5f);

        reel2.Spin();

        yield return new WaitForSeconds(0.5f);

        reel3.Spin();

        while (reel1.IsSpinning ||
               reel2.IsSpinning ||
               reel3.IsSpinning)
        {
            yield return null;
        }

        Debug.Log("All reels stopped.");

        resultEvaluator.Evaluate(
            reel1.CurrentResult,
            reel2.CurrentResult,
            reel3.CurrentResult
        );
    }
}