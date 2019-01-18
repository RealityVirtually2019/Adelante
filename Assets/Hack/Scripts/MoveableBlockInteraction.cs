using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class MoveableBlockInteraction : MonoBehaviour
    {
        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);


        //-------------------------------------------------
        // Called every Update() while a Hand is hovering over this object
        //-------------------------------------------------
        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
            {
                if (hand.currentAttachedObject != gameObject)
                {
                    // Call this to continue receiving HandHoverUpdate messages,
                    // and prevent the hand from hovering over anything else
                    hand.HoverLock(GetComponent<Interactable>());

                    // Attach this object to the hand
                    hand.AttachObject(gameObject, attachmentFlags);
                }
                else
                {
                    // Detach this object from the hand
                    hand.DetachObject(gameObject);

                    // Call this to undo HoverLock
                    hand.HoverUnlock(GetComponent<Interactable>());
                }
            }
        }
    }
}
