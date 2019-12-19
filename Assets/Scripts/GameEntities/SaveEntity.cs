using System;

[Serializable]
public class SaveEntity : BaseSaveEntity
{
    public SaveEntity() { }
    public SaveEntity(string questID, RatingEntity ratingEntity)
    {
        _questID = questID;
        _ratingEntity = ratingEntity;
    }

    string _questID;
    RatingEntity _ratingEntity;

    public RatingEntity GetRating()
    {
        return _ratingEntity;
    }

    public string GetQuestID()
    {
        return _questID;
    }
}
