using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tangga : MonoBehaviour
{
    // Start is called before the first frame update
    private enum LadderPart { whole, atas, bawah};
    [SerializeField] LadderPart part = LadderPart.whole;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>())
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            switch (part)
            {
                case LadderPart.whole:
                    player.canClimb = true;
                    player.tangga = this;
                    break;
                case LadderPart.bawah:
                    player.bawahtangga = true;
                    break;
                case LadderPart.atas:
                    player.atastangga = true;
                    break;
                default:
                    break;
            }
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            switch (part)
            {
                case LadderPart.whole:
                    player.canClimb = false;

                    break;
                case LadderPart.bawah:
                    player.bawahtangga = false;
                    break;
                case LadderPart.atas:
                    player.atastangga = false;
                    break;
                default:
                    break;
            }
        }
    }
}
