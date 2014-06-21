namespace likeothers.Models.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using likeothers.Models.Data;

    public class TestMethods : IAction
    {
        private IRepository _repository;

        public TestMethods()
        {
            _repository = new EFRepository();
        }

        public TestMethods(IRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<StatView> GetAllPeople() //return amount of all people who respond on each questions
        {
            return _repository.GetAllPeople();           
        }
        public IQueryable<StatView> GetSameAns(List<int> listResult) // return amount of people who selected the same answer on each questions
        {
            return _repository.GetSameAns(listResult);
        }
        public String GetResultText(int result)
        {
            return _repository.GetResultText(result);
        }
        public void SendResult(List<int> listResult)
        {
            foreach (int selId in listResult)
            {
                _repository.SendResult(selId);
            }
        }
        public int CountUserStat(IQueryable<StatView> allPeople, IQueryable<StatView> sameAns)
        {
            float resultSum = 0;
            float ammountOfQ = 0;
            IQueryable<StatView> userStat = _repository.GetUserStat(allPeople, sameAns);   

            foreach (var quest in userStat)
            {
                resultSum += quest.sumation;
                ammountOfQ++;
            }

            int result;
            //to avoid division 0
            if (ammountOfQ == 0)
                result = 50;
            else
                result = (int)((resultSum / ammountOfQ) * 100.0); //* 100%

            return result;
        }
        
    }
}