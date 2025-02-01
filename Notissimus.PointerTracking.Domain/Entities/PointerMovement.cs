using Microsoft.EntityFrameworkCore;
using Notissimus.PointerTracking.Domain.Dtos;

namespace Notissimus.PointerTracking.Domain.Entities;

[PrimaryKey(nameof(Id))]
public class PointerMovement
{
    public long Id { get; set; }
    public string Json { get; set; }
}
    