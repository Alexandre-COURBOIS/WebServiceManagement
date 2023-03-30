using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceManagement.Core.Entity
{
    public class AgencyEntity
    {
        protected string _id;

        protected string _code;

        protected string _libelle;

        public string Id 
        { 
            get { return _id; }
            set { _id = value; }
        }
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string Libelle
        {
            get { return _libelle; }
            set { _libelle = value; }
        }
    }
}
