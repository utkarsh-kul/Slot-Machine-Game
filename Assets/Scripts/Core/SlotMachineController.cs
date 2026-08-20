using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineController : MonoBehaviour
{
    [Header("Reels")]
    [SerializeField] private ReelController reel1;
    [SerializeField] private ReelController reel2;
    [SerializeField] private ReelController reel3;

    [Header("Result")]
    [SerializeField] private SlotResultEvaluator resultEvaluator;

    [Header("Economy")]
    [SerializeField] private SlotMachineEconomy economy;

    [Header("Lever")]
    [SerializeField] private Image leverImage;
    [SerializeField] private Sprite leverIdleSprite;
    [SerializeField] private Sprite leverPressedSprite;

    [SerializeField] private float leverPressDuration = 0.15f;

    [Header("Audio")]
    [SerializeField] private SlotMachineAudio audioController;

    public void SpinAll()
    {
        // Don't start another spin while reels are running.
        if (reel1.IsSpinning || reel2.IsSpinning || reel3.IsSpinning)
            return;

        // Check and spend credits BEFORE doing anything visually.
        if (!economy.SpendForSpin())
        {
            Debug.Log("Not enough credits to spin.");
            return;
        }

        StartCoroutine(SpinSequence());
    }

    private IEnumerator SpinSequence()
    {
        // Press lever visually
        leverImage.sprite = leverPressedSprite;
        audioController.PlayLeverPull();

        yield return new WaitForSeconds(leverPressDuration);

        // Set results
        reel1.SetRandomResult();
        reel2.SetRandomResult();
        reel3.SetRandomResult();

        // Start reels
        reel1.Spin();

        yield return new WaitForSeconds(0.5f);

        reel2.Spin();

        yield return new WaitForSeconds(0.5f);

        reel3.Spin();

        // Return lever to idle
        leverImage.sprite = leverIdleSprite;

        // Wait until all reels stop
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