using System.Collections;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform symbolStrip;

    [Header("Spin Settings")]
    [SerializeField] private float spinDuration = 3f;
    [SerializeField] private float spinSpeed = 900f;

    [Header("Symbol Layout")]
    [SerializeField] private float symbolSpacing = 125f;
    [SerializeField] private float symbolHeight = 100f;
    [SerializeField] private float reelHeight = 323f;
    [SerializeField] private int symbolCount = 8;

    private bool isSpinning;

    public bool IsSpinning => isSpinning;

    public void Spin()
    {
        if (isSpinning)
            return;

        StartCoroutine(SpinRoutine());
    }

    private IEnumerator SpinRoutine()
    {
        isSpinning = true;

        float elapsedTime = 0f;

        while (elapsedTime < spinDuration)
        {
            MoveStrip();

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        isSpinning = false;
    }

    private void MoveStrip()
    {
        // Move the entire symbol strip downward.
        symbolStrip.anchoredPosition +=
            Vector2.down * spinSpeed * Time.deltaTime;

        // Check every symbol and recycle it when it leaves
        // the bottom of the reel.
        for (int i = 0; i < symbolStrip.childCount; i++)
        {
            RectTransform symbol =
                symbolStrip.GetChild(i) as RectTransform;

            if (symbol == null)
                continue;

            float symbolWorldY =
                symbolStrip.anchoredPosition.y +
                symbol.anchoredPosition.y;

            float bottomLimit =
                -(reelHeight / 2f) - symbolHeight;

            if (symbolWorldY < bottomLimit)
            {
                // Move this symbol to the top of the strip.
                symbol.anchoredPosition +=
                    Vector2.up * (symbolSpacing * symbolCount);
            }
        }
    }
}