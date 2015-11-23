using UnityEngine;
using System.Collections;

public class Variables {

    public const int GREEN = 0;
    public const int YELLOW = 1;
    public const int RED = 2;

    public static float Health;
    public static float MaxHealth = 8;

    public static int Score;
    public static int MaxScore = 999;

    public static bool HealthHasChanged;

    public static bool FadeOutStart;
    public static bool TrueEnd;

    public static void InitVars()
    {
        Health = MaxHealth;
        FadeOutStart = false;
        TrueEnd = false;
    }
    public static bool HealthDecrement(float lives = 1f)
    {
        Health = Health - lives;
        if (Health <= 0f)
        {
            Health = 0f;
            HealthHasChanged = true;
            return true;    // if player is dead, say 'true'
        }
        return false;
    }
    public static bool HealthIncrement(float lives = 1f)
    {
        Health += lives;
        if (Health>=MaxHealth)
        {
            Health = MaxHealth;
            return true;    // if life is maxed, say 'true'
        }
        return false;
    }
    public static bool scoreIncrement(int unit = 1)
    {
        if (Score >= MaxScore) return true;
        Score = Score + unit;
        if (Score >= MaxScore)
        {
            Score = MaxScore;
            return true;
        }
        return false;
    }
    public static bool scoreDecrement(int unit = 1)
    {
        if (Score <= 0) return true;
        Score = Score - unit;
        if (Score<=0)
        {
            Score = 0;
            return true;
        }
        return false;
    }
    
	// Use this for initialization
	void Start () {
        InitVars();
	}
	
	// Update is called once per frame
	public static void Update () {
     //   HealthHasChanged = false;
    }
}
