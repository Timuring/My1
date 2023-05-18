using System;
using System.Collections.Generic;

namespace WPF_POSUDA.Models;

public partial class Pickuppoint
{
    public int PickUpPointId { get; set; }

    public string PickUpPointIndex { get; set; } = null!;

    public string PickUpPointName { get; set; } = null!;
}
