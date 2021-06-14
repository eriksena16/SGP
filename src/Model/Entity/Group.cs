using System.Collections.Generic;

namespace SGP.Model.Entity
{
    class Group : GenericEntity
    {
        public ICollection<User_> User_ { get; set; }
    }
}
