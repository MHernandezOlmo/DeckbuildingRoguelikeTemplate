using System;

public static class RandomManager
{
    private static System.Random _random;

    private static System.Random _mapRandom;
    
    public static void Initialize(int seed)
    {
        _random = new System.Random(seed);
    }

    // Get a random integer between min (inclusive) and max (exclusive)
    public static int GetRandomInt(int min, int max)
    {
        if (_random == null)
        {
            _random = new Random(PersistenceManager.Instance._myCurrentRun._seed);
        }
        return _random.Next(min, max);
    }

    public static int GetRandomMapInt(int min, int max)
    {
        if (_mapRandom == null)
        {
            _mapRandom = new Random(PersistenceManager.Instance._myCurrentRun._seed);
        }
        return _mapRandom.Next(min, max);
    }

    public static void ResetMapRandomSeed()
    {
        _mapRandom = new Random(PersistenceManager.Instance._myCurrentRun._seed);
    }
    

    public static float GetRandomFloat()
    {
        if (_random == null)
        {
            _random = new Random(PersistenceManager.Instance._myCurrentRun._seed);
        }
        return (float)_random.NextDouble();
    }

}