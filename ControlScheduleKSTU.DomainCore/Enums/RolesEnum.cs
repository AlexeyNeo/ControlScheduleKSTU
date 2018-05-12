using System;

namespace ControlScheduleKSTU.DomainCore.Enums
{
    [Flags]
    public enum RolesEnum
    {
        Admin = 1,
        Student = 2,
        Teacher = 4,
    }
}