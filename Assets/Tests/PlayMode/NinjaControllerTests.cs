using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NeonNinja;

namespace NeonNinja.PlayMode.Tests
{
    public class NinjaControllerTests
    {
        private GameObject ninjaGameObject;
        private NinjaController ninjaController;
        private InputHandler inputHandler;
        private FocusMeter testFocusMeter;
        private GameObject slashPrefab;

        [SetUp]
        public void Setup()
        {
            // Create the Ninja Game Object
            ninjaGameObject = new GameObject("Ninja");
            inputHandler = ninjaGameObject.AddComponent<InputHandler>();
            ninjaController = ninjaGameObject.AddComponent<NinjaController>();

            ninjaController.inputHandler = inputHandler;

            // Setup a Dummy FocusMeter ScriptableObject
            testFocusMeter = ScriptableObject.CreateInstance<FocusMeter>();
            testFocusMeter.maxFocus = 10;
            ninjaController.focusMeter = testFocusMeter;

            // Setup a Dummy Slash Prefab
            slashPrefab = new GameObject("DummySlashPrefab");
            var slashEffect = slashPrefab.AddComponent<SlashEffect>();
            ninjaController.slashEffectPrefab = slashPrefab;
        }

        [TearDown]
        public void Teardown()
        {
            Object.DestroyImmediate(ninjaGameObject);
            Object.DestroyImmediate(testFocusMeter);
            Object.DestroyImmediate(slashPrefab);

            // Clean up any instantiated slashes
            var slashes = Object.FindObjectsByType<SlashEffect>(FindObjectsSortMode.None);
            foreach (var slash in slashes)
            {
                Object.DestroyImmediate(slash.gameObject);
            }
        }

        [UnityTest]
        public IEnumerator Swipe_InstantiatesSlashAndIncrementsFocus()
        {
            // Wait one frame to allow Start() and setup to run
            yield return null;

            // Arrange
            int initialFocus = testFocusMeter.currentFocus;
            Vector2 dummySwipeVector = new Vector2(1, 1);

            // Verify no slashes exist yet (except prefab)
            var slashesBefore = Object.FindObjectsByType<SlashEffect>(FindObjectsSortMode.None);
            Assert.AreEqual(1, slashesBefore.Length, "Only the prefab should exist initially.");

            // Act - Force the event to fire as if a swipe occurred
            inputHandler.OnSwipe.Invoke(dummySwipeVector);

            // Yield one frame to allow instantiation/logic to process
            yield return null;

            // Assert
            // 1. Check if FocusMeter incremented
            Assert.AreEqual(initialFocus + 1, testFocusMeter.currentFocus, "FocusMeter should increment by 1 after a swipe.");

            // 2. Check if a new SlashEffect was instantiated
            var slashesAfter = Object.FindObjectsByType<SlashEffect>(FindObjectsSortMode.None);
            Assert.AreEqual(2, slashesAfter.Length, "A new SlashEffect instance should have been instantiated alongside the prefab.");
        }
    }
}
