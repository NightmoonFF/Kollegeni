﻿namespace Kollegeni.Models;
public class Event
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }

    public int TenantId { get; set; }
    public virtual Residency Residency { get; set; }
}
