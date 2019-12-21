using System;

[Serializable]
public class RatingEntity
{
    public RatingEntity()
    {
        intelligence = 0;
        respect = 0;
    }

    public uint intelligence;
    public uint respect;
}
