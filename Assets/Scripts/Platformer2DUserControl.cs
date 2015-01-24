using UnityEngine;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D character;
        private bool jump;
		public bool paused;

        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
			paused = false;
        }

        private void Update()
        {
            if (!paused) {
					if (!jump)
            		// Read the jump input in Update so button presses aren't missed.
					jump = Input.GetButtonDown ("Jump");

					if (Input.GetKeyDown (KeyCode.Escape)) {
										Debug.Log ("Escape is pressed");
					}
				}
        }

        private void FixedUpdate()
        {
						if (!paused) {
								// Read the inputs.
								bool crouch = Input.GetKey (KeyCode.LeftControl);
								float h = Input.GetAxis ("Horizontal");
								// Pass all parameters to the character control script.
								character.Move (h, crouch, jump);
								jump = false;
						}
				}
    }
}