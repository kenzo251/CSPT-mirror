﻿using Enums;
using System.ComponentModel.DataAnnotations;

namespace webapi.Entities {
    public class SwimmingPool {
        public Guid Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Street { get; set; }

        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public LaneLength LaneLength { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<Race> Races { get; set; }
    }
}
