using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : Button {

	protected override void Activate()
    {
		Results.reasons.Clear();
		
        // Load new scene asynchronously
        LoadScene scene_loader = GetComponent<LoadScene>();
        scene_loader.Load();

        // When finished, migrate to new scene
    }
}
