using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class BusinessEntity
    {
        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }
        
        private int _ID;
        private States _State;

       
        public BusinessEntity()
        {
            this.State = States.New;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public States State
        {
            get { return _State; }
            set { _State = value; }
        }
        


    }
}
