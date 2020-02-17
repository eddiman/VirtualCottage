using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK.Prefabs.Locomotion.Teleporters;
using Zinnia.Data.Type;

namespace EscapeRoom.Scripts
{
    public class PauseMenuLogic : MonoBehaviour
    {
        public TeleporterFacade teleporter;
        public Transform playArea;
        public Transform headOrientation;
        public Transform pauseLocation;
        public Transform gameLocation;

        public bool _inPauseMenu = false;

        public List<GameObject> pauseItems;
        public List<GameObject> gameItems;

        public GameObject teleportationRelease;
        public GameObject teleportationPress;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SwitchRooms();
                Debug.Log("Pausemenulogi");

            }
        }

        public void SwitchRooms() {

            TransformData teleportDestination = new TransformData(gameLocation);

            if (!_inPauseMenu) {
                gameLocation.position = new Vector3(headOrientation.position.x, playArea.position.y, headOrientation.position.z);

                Vector3 right = Vector3.Cross(playArea.up, headOrientation.forward);
                Vector3 forward = Vector3.Cross(right, playArea.up);

                gameLocation.rotation = Quaternion.LookRotation(forward, playArea.up);

                teleportDestination = new TransformData(pauseLocation);
            }
            Debug.Log(teleportDestination.Position.x);
            Debug.Log(teleportDestination.Position.y);
            Debug.Log(teleportDestination.Position.z);
            teleporter.Teleport(teleportDestination);
            _inPauseMenu = !_inPauseMenu;

            foreach (GameObject item in pauseItems) {
                item.SetActive(_inPauseMenu);
            }

            foreach (GameObject item in gameItems) {
                item.SetActive(!_inPauseMenu);
            }
        }
        public void ResetGame() {
            SceneManager.LoadScene("Final", LoadSceneMode.Single);
        }

        public void SwitchTeleportationToPress(bool value) {
            teleportationRelease.SetActive(!value);
            teleportationPress.SetActive(value);
        }
        public void SwitchTeleportationToRelease(bool value) {
            SwitchTeleportationToPress(!value);
        }
    }
}
