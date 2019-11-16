/**
 * Copyright (c) 2017 The Campfire Union Inc - All Rights Reserved.
 *
 * Licensed under the MIT license. See LICENSE file in the project root for
 * full license information.
 *
 * Email:   info@campfireunion.com
 * Website: https://www.campfireunion.com
 */

using UnityEngine;
using System.Collections;
using VRTK;
using TMPro;

namespace VRKeys {

	/// <summary>
	/// Enter key that calls Submit() on the keyboard.
	/// </summary>
	public class EnterKey : Key {
        public GameObject panels;
        public GameObject leftController;
        public GameObject RightController;
        public GameObject drumone, drumtwo;
        public GameObject Keyboard;
        public TextMeshProUGUI mainText;
        public override void HandleTriggerEnter (Collider other) {
            UiManager.Instance.name = mainText.text;

            panels.SetActive(true);
            drumone.SetActive(false);
            drumtwo.SetActive(false);
            leftController.GetComponent<VRTK_StraightPointerRenderer>().enabled = true;
            RightController.GetComponent<VRTK_StraightPointerRenderer>().enabled = true;
       Keyboard.SetActive(false);
        }

        public override void UpdateLayout (Layout translation) {
			label.text = translation.enterButtonLabel;
		}
	}
}