using System;
using System.Xml.Serialization;

public enum RatingPoint
{
    Intelligence,
    Respect
}

public class RatingManager
{
    static RatingManager Instance;

    RatingEntity ratingEntity;

    public static RatingManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new RatingManager();
            Instance.Load();
        }
        return Instance;
    }

    public void Load()
    {
        ratingEntity = GameManagerBehaviour.GetInstance().GetSaveManager().GetRating();
        if (ratingEntity == null)
        {
            ratingEntity = new RatingEntity();
        }
    }

    public RatingEntity GetRating()
    {
        return ratingEntity;
    }

    public void Add(RatingPoint rating, uint value)
    {
        switch(rating)
        {
            case RatingPoint.Intelligence: ratingEntity.intelligence += value; break;
            case RatingPoint.Respect: ratingEntity.respect += value;  break;
        }
    }
}
