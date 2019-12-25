using System;

[Serializable]
public class RatingEntity
{
    public RatingEntity()
    {
        intelligence = 0;
        respect = 0;
    }

    public RatingEntity(uint intelligence, uint respect)
    {
        this.intelligence = intelligence;
        this.respect = respect;
    }

    public RatingEntity(int intelligence, int respect)
    {
        this.intelligence = Convert.ToUInt32(intelligence);
        this.respect = Convert.ToUInt32(respect);
    }

    public uint intelligence;
    public uint respect;
}
