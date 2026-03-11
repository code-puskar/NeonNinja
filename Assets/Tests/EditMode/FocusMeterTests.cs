using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NeonNinja;

namespace NeonNinja.EditMode.Tests
{
    public class FocusMeterTests
    {
        private FocusMeter focusMeter;

        [SetUp]
        public void Setup()
        {
            // Create a temporary ScriptableObject for testing
            focusMeter = ScriptableObject.CreateInstance<FocusMeter>();
            focusMeter.maxFocus = 10;
        }

        [TearDown]
        public void Teardown()
        {
            Object.DestroyImmediate(focusMeter);
        }

        [Test]
        public void Add_WhenBelowMax_IncrementsValue()
        {
            // Arrange
            int initialValue = focusMeter.currentFocus;
            int addAmount = 5;

            // Act
            focusMeter.Add(addAmount);

            // Assert
            Assert.AreEqual(initialValue + addAmount, focusMeter.currentFocus);
        }

        [Test]
        public void Add_WhenAtMax_DoesNotOverflow()
        {
            // Arrange
            focusMeter.Add(10); // Fill it up
            Assert.AreEqual(10, focusMeter.currentFocus);

            // Act
            focusMeter.Add(5); // Try to overfill

            // Assert
            Assert.AreEqual(10, focusMeter.currentFocus, "Focus meter should not exceed maxFocus.");
        }

        [Test]
        public void OnFull_EventFiresExactlyOnce()
        {
            // Arrange
            int eventFireCount = 0;
            focusMeter.OnFull.AddListener(() => eventFireCount++);

            // Act
            focusMeter.Add(9); // Not full yet
            Assert.AreEqual(0, eventFireCount, "Event should not fire prematurely.");

            focusMeter.Add(1); // Exactly full
            Assert.AreEqual(1, eventFireCount, "Event should fire once when full.");

            focusMeter.Add(5); // Overfill

            // Assert
            Assert.AreEqual(1, eventFireCount, "Event should not fire again when already full.");
        }
    }
}
