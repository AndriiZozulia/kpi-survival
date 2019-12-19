using System;

[Serializable]
public class RatingEntity
{
    public RatingEntity()
    {
        intelligence = 0;
        force = 0;
    }

    public uint intelligence;
    public uint force;
}
