

namespace Core.Entities;

public partial class Team : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<TeamDriver> TeamDrivers { get; set; }
    public ICollection<Driver> Drivers { get; set; }  = new HashSet<Driver>(); 
}
