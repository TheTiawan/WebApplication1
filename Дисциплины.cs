using System;
using System.Collections.Generic;

namespace WebApplication1;

public partial class Дисциплины
{
    public int КодДисциплины { get; set; }

    public string Название { get; set; } = null!;

    public string? Направление { get; set; }

    public virtual ICollection<УчебнаяНагрузка> УчебнаяНагрузкаs { get; set; } = new List<УчебнаяНагрузка>();
}
