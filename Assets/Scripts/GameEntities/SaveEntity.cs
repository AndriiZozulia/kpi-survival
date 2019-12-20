using System;

namespace Entity
{
    [Serializable]
    public class SaveEntity : BaseSaveEntity
    {
        public SaveEntity() { }
        public SaveEntity(string questID, RatingEntity ratingEntity)
        {
            _questID = questID;
            _ratingEntity = ratingEntity;
            _actionIndex = 0;
        }

        string _questID;
        RatingEntity _ratingEntity;
        int _actionIndex;

        public RatingEntity GetRating()
        {
            return _ratingEntity;
        }

        public string GetQuestID()
        {
            return _questID;
        }

        public int GetActionIndex()
        {
            return _actionIndex;
        }

        public static SaveEntity CreateSave(bool newSave)
        {
            SaveEntity save = new SaveEntity
            {
                _questID = newSave ? QuestManager.GetFirstQuestID() : QuestManager.GetInstance().GetCurrQuestID(),
                _ratingEntity = newSave ? new RatingEntity() : RatingManager.GetInstance().GetRating(),
                _actionIndex = newSave ?  0 : StoryControlerManager.GetInstance().GetActionIndex()
            };

            return save;
        }
    }
}