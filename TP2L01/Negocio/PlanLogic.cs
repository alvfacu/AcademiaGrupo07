using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class PlanLogic: BusinessLogic
    {
        private Data.Database.PlanAdapter _PlanData;

        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();
        }

        public Data.Database.PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }
    }
}
