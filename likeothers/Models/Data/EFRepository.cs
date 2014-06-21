namespace likeothers.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using likeothers.Models;

    public class EFRepository : IRepository 
    {
        private EntitiesConnection db = new EntitiesConnection();
        public IQueryable<StatView> GetAllPeople()
        {
                return (
                        from ur in db.UsersResults
                        group ur.Amount by ur.Option.Question.Id into s
                        select new StatView() { idQ = s.Key, sumation = s.Sum() }
                       );
        }
        public IQueryable<StatView> GetSameAns(List<int> listResult)
        {
            return (
                 from ur in db.UsersResults
                 where listResult.Contains(ur.IdOption)
                 group ur.Amount by ur.Option.Question.Id into s
                 select new StatView() { idQ = s.Key, sumation = s.Sum() }
                );
        }
        public String GetResultText(int result)
        {
            return (
                    from r in db.ResultTexts
                    where (r.Min <= result) && (result <= r.Max)
                    select r.Text
                ).Single();
        }
        public void SendResult(int selId )
        {
                UsersResult el = db.UsersResults.Find(selId);
                el.Amount = el.Amount + 1;
                db.SaveChanges();
        }
        public IQueryable<StatView> GetUserStat(IQueryable<StatView> allPeople, IQueryable<StatView> sameAns)
        {
            return (
                from ap in allPeople
                join sa in sameAns on ap.idQ equals sa.idQ
                where ap.sumation != 0
                select new StatView() { idQ = ap.idQ, sumation = (float)sa.sumation / (float)ap.sumation }
                );                              
        }
        public int GetQuestCount()
        {
            return db.Questions.Count();
        }
        public List<Option> FindQuestions(int id)
        {
            return db.Questions.Find(id).Options.ToList();
        }
    }
}