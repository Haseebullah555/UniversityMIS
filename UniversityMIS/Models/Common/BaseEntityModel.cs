﻿namespace UniversityMIS.Models.Common
{
    public class BaseEntityModel
    {
        public int Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
