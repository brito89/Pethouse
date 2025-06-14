﻿namespace PethouseAPI.Data.DTO;

public class PeakSeasonDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateOnly StartDate { get; set; }
    public required DateOnly EndDate { get; set; }
}
