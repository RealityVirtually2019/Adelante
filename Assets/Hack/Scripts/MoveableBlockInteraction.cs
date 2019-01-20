using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class MoveableBlockInteraction : MonoBehaviour
    {
        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);

        private bool mailSent = false;

        private Emailer mailer;

        void Awake()
        {

            mailer = GetComponent<Emailer>();

        }


        private void OnHandHoverBegin(Hand hand)
        {
            if (!mailSent)
            {

                mailer.SendMail();

                mailSent = true;

            }
        }
    }
}
