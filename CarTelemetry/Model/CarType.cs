using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTelemetry.Model
{
    public enum CarType
    {
        [Display(Name = "SUV")]
        SUV,
        [Display(Name = "Micro")]
        Micro,
        [Display(Name = "Minivan")]
        Minivan,
        [Display(Name = "Sedan")]
        Sedan,
        [Display(Name = "CUV")]
        CUV,
        [Display(Name = "Roadster")]
        Roadster
    }
}
