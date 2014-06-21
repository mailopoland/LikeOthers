namespace likeothers.Models.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public interface IAction
    {
        IQueryable<StatView> GetAllPeople();
        IQueryable<StatView> GetSameAns(List<int> listResult);
        String GetResultText(int result);
        void SendResult(List<int> listResult);
        int CountUserStat(IQueryable<StatView> allPeople, IQueryable<StatView> sameAns);
    }
}