using System.ComponentModel;

namespace Garage.API.Domain.Models
{
    public enum ECustomerType : byte
    {
        [Description("Regular")]
        Regular = 1,

        [Description("Gold")]
        Gold = 2,

        [Description("Platinum")]
        Platinum = 3
    }
}
