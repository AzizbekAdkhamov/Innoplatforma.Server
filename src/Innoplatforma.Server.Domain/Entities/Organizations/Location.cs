using Innoplatforma.Server.Domain.Commons;

namespace Innoplatforma.Server.Domain.Entities.Organizations;

public class Location : Auditable<long>
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
