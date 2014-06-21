namespace likeothers.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;

    public interface IRepository 
    {
        IQueryable<StatView> GetAllPeople();
        IQueryable<StatView> GetSameAns(List<int> listResult);
        String GetResultText(int result);
        void SendResult(int selId);
        IQueryable<StatView> GetUserStat(IQueryable<StatView> allPeople, IQueryable<StatView> sameAns);
        int GetQuestCount();
        List<Option> FindQuestions(int id);
    }
}