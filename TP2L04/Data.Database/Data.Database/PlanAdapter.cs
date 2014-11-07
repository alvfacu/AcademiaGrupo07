using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    public class PlanAdapter: Adapter
    {
        private static List<Plan> _Plan;

        private static List<Plan> Plan
        {
            get
            {
                if (_Plan == null)
                {
                    _Plan = new List<Business.Entities.Plan>();
                    Business.Entities.Plan plan;
                    plan = new Business.Entities.Plan();
                    plan.ID = 1;
                    plan.State = Business.Entities.BusinessEntity.States.Unmodified;
                    plan.Descripcion = "Plan 1998";
                    plan.IDEspecialidad = 1;
                    _Plan.Add(plan);

                    plan = new Business.Entities.Plan();
                    plan.ID = 2;
                    plan.State = Business.Entities.BusinessEntity.States.Unmodified;
                    plan.Descripcion = "Plan 2008";
                    plan.IDEspecialidad = 1;
                    _Plan.Add(plan);

                    plan = new Business.Entities.Plan();
                    plan.ID = 6;
                    plan.State = Business.Entities.BusinessEntity.States.Unmodified;
                    plan.Descripcion = "Plan 2005";
                    plan.IDEspecialidad = 3;
                    _Plan.Add(plan);
                }
                return _Plan;
            }
        }

        public List<Plan> GetAll()
        {
            return new List<Plan>(Plan);
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            return Plan.Find(delegate(Plan pl) { return pl.ID == ID; });
        }

        public void Delete(int ID)
        {
            Plan.Remove(this.GetOne(ID));
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Plan pl in Plan)
                {
                    if (pl.ID > NextID)
                    {
                        NextID = pl.ID;
                    }
                }
                plan.ID = NextID + 1;
                Plan.Add(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                Plan[Plan.FindIndex(delegate(Plan p) { return p.ID == plan.ID; })] = plan;
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
