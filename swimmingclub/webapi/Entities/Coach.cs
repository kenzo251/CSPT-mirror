﻿using Enums;
using System.ComponentModel.DataAnnotations;

namespace webapi.Entities {
    public class Coach : Member{
        [Required]
        public Level Level { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
