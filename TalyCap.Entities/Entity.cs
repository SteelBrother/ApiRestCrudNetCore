using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalyCap.Abstraction;

namespace TalyCap.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get;set; }
    }
}
