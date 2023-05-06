using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
        private bool z_Interacted = false;
        private Collider2D a_collider2D;
        public TMP_Text pressKey;

        private void OnTriggerEnter(Collider a_collider2D)
        {
                if (!z_Interacted)
                {
                        pressKey.text = "Press 'V'";
                }

                if (Input.GetKey(KeyCode.V))
                {
                        z_Interacted = true;
                        pressKey.text = " ";
                }
        }

        private void OnTriggerExit(Collider other)
        {
                z_Interacted = false;
        }
}
