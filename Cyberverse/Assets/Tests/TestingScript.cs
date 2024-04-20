using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.UIElements;

public class TestingScript
{
    [UnityTest]
    public IEnumerator CharacterMovement()
    {
        yield return new WaitForSeconds(.1f);
    }

    [UnityTest]
    public IEnumerator CharacterInteract()
    {
        yield return new WaitForSeconds(.1f);
    }

    [UnityTest]
    public IEnumerator CharacterJump()
    {
        yield return new WaitForSeconds(.1f);
    }

    [UnityTest]
    public IEnumerator NpcInteract()
    {
        yield return new WaitForSeconds(.1f);
    }

    [UnityTest]
    public IEnumerator ScoreUpdate()
    {
        yield return new WaitForSeconds(.1f);
    }

    [UnityTest]
    public IEnumerator LevelCompletion()
    {
        yield return new WaitForSeconds(.1f);
    }
}
