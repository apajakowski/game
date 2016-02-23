using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour
{
    Character character;

    void Start()
    {
        character = GameObject.Find("Character").GetComponent<Character>();
    }
    public void RestartLevel()
    {
        Debug.Log("test");
        Application.LoadLevel("Scene1");
    }
    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
    /*
    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 80, 40), "Reset"))
            Application.LoadLevel(Application.loadedLevel);

        if (GUI.Button(new Rect(110, 20, 80, 40), "Die"))
            character.Dying = true;

        if (GUI.Button(new Rect(200, 20, 80, 40), "Explode"))
            character.Explode();

        if (GUI.Button(new Rect(290, 20, 80, 40), "Shoot"))
            GameObject.Find("BulletSpawner").GetComponent<RangedWeaponController>().Shoot(ProjectileType.bullet1);
    }
     */
}
