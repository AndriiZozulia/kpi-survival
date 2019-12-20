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
                _questID = newSave ? QuestManager.GetFirstQuestID() : GameManagerBehaviour.GetInstance().GetQuestManager().GetCurrQuestID(),
                _ratingEntity = newSave ? new RatingEntity() : GameManagerBehaviour.GetInstance().GetRatingManager().GetRating(),
                _actionIndex = newSave ?  0 : GameManagerBehaviour.GetInstance().GetStoryControlerManager().GetActionIndex()
            };

            return save;
        }
    }
}