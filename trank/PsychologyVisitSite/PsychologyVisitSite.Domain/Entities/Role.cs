﻿
namespace PsychologyVisitSite.Domain.Entities
{
   public  class Role
    {
       public int ID { get; set; }

       public string Code { get; set; }

       public string Name { get; set; }

       public UserRole UserRoles { get; set; }
    }
}
