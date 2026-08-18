using UnityEngine;

public class SlotResultEvaluator : MonoBehaviour
{
    public void Evaluate(
        SymbolType reel1Result,
        SymbolType reel2Result,
        SymbolType reel3Result)
    {
        if (reel1Result == reel2Result &&
            reel2Result == reel3Result)
        {
            switch (reel1Result)
            {
                case SymbolType.Seven:
                    Debug.Log("JACKPOT! 7 - 7 - 7");
                    break;

                case SymbolType.Cherry:
                    Debug.Log("BIG WIN! Cherry - Cherry - Cherry");
                    break;

                case SymbolType.Bell:
                    Debug.Log("WIN! Bell - Bell - Bell");
                    break;

                case SymbolType.Bar:
                    Debug.Log("WIN! BAR - BAR - BAR");
                    break;
            }
        }
        else
        {
            Debug.Log("No Win");
        }
    }
}