﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlScheduleKSTU.DomainCore.ModelsView
{
    public class AuditoriumViewModel
    {
            public short Id { get; set; }

            public string Name { get; set; }

            public string Department { get; set; }

            public short SeatingCapacity { get; set; }

            public string AuditoriumType { get; set; }

            public string Building { get; set; }
        }
}
