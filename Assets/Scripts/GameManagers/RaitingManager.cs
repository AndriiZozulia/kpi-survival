using System;
using System.Xml.Serialization;

public enum RatingPoint
{
    Intelligence,
    Force
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
        ratingEntity = SaveManager.GetInstance().GetRating();
        if (ratingEntity == null)
        {
            ratingEntity = new RatingEntity();
        }
    }

    public RatingEntity Getrating()
    {
        return ratingEntity;
    }

    public void Add(RatingPoint rating, uint value)
    {
        switch(rating)
        {
            case RatingPoint.Intelligence: ratingEntity.intelligence += value; break;
            case RatingPoint.Force: ratingEntity.force += value;  break;
        }
    }
}
